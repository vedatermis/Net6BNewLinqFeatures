using Net6LINQFeatures;

List<Product> products = new List<Product>
{
    new Product { ProductId = 1, ProductName = "Product 1", Quantity = 10, Price = 15.7 },
    new Product { ProductId = 2, ProductName = "Product 2", Quantity = 5, Price = 7.25 },
    new Product { ProductId = 3, ProductName = "Product 3", Quantity = 22, Price = 6.95 },
    new Product { ProductId = 4, ProductName = "Product 4", Quantity = 1, Price = 12.0 },
    new Product { ProductId = 5, ProductName = "Product 5", Quantity = 0, Price = 8.98 },
};


var firstThreeProducts = products.Where(x => x.ProductId <= 3);
var lastThreeProducts = products.Where(x => x.ProductId > 3);

var unionBy = firstThreeProducts.UnionBy(lastThreeProducts, x => x.ProductId);
var intersectionBy = firstThreeProducts.IntersectBy(lastThreeProducts.Select(p => p.ProductId), x => x.ProductId);
var distinctBy = products.DistinctBy(x => x.Price);
var exceptBy = products.ExceptBy(firstThreeProducts, product => product);


IEnumerable<Product[]> cluster = products.Chunk(3);

foreach (var product in cluster)
{
    Console.WriteLine($"Cluster of {string.Join(",", product.Select(product => product.ProductName))}");
}

var cheapestProduct = products.MinBy(product => product.Price);
Console.WriteLine(cheapestProduct!.ProductName);

var expensiveProduct = products.MaxBy(product => product.Price);
Console.WriteLine(expensiveProduct!.ProductName);


var secondLastProduct = products.ElementAt(^2);
//Product 4

var take2Product = products.Take(..2);
//Product 1, Product 2

var skip3Product = products.Take(3..);
//Product 4, Product 5

var take3Skip1Product = products.Take(1..3);
//Product 2, Product 3

var takeLast2Products = products.Take(^2..);
//Product 4, Product 5

var skipLast3Products = products.Take(..^3);
//Product 1, Product 2

var takeLast3SkipLast2 = products.Take(^3..^2);
//Product 3


List<Product> list = products.TryGetNonEnumeratedCount(out int count) ? new List<Product>(count): new List<Product>();
list.AddRange(products);

List<string> emptyList = new List<string>();
var value = emptyList.FirstOrDefault("Empty");

var prices = products.Select(s => s.Price);
var allProducts = products;
var productIds = products.Select(s => s.ProductId);

var zipped = prices.Zip(allProducts, productIds);
