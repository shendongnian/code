    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
    var products = new List<Product>();
    products.Add(new Product { Name = "TV", Price = 400, Category = "Electronics" });
    products.Add(new Product { Name = "Computer", Price = 900, Category = "Electronics" });
    products.Add(new Product { Name = "Keyboard", Price = 50, Category = "Electronics" });
    products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
    products.Add(new Product { Name = "Grape", Price = 3, Category = "Fruits" });
    // group by category
    ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
    foreach (var item in lookup)
    {
        // this first loop would run two times
        // because there are two categories: Electronics and Fruits
        string category = item.Key;
        decimal totalPriceForCategory = item.Sum(i => i.Price);
        foreach (var product in item)
        {
            // for the electronics, this would loop three times
            // for the fruits, this would loop two times
            string name = product.Name;
            decimal price = product.Price;
        }
    }
