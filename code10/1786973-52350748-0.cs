    class Product
    {
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        var products = new List<Product> {
            new Product { Name = "ZZZ"},
            new Product { Name = "AAA"}
        };
        var propertyName = "Name";
        var ordered = products.AsQueryable().OrderBy(GetOrderExpression<string>(propertyName));
        Console.WriteLine(ordered.ElementAt(0).Name);
        Console.WriteLine(ordered.ElementAt(1).Name);
        var filtered = products.AsQueryable().Where(GetWhereExpression(propertyName, "AAA"));
        Console.WriteLine(filtered.Count());
        Console.WriteLine(filtered.ElementAt(0).Name);
        Console.ReadKey();
    }
    static Expression<Func<Product, TKey>> GetOrderExpression<TKey>(string propertyName)
    {
        var prm = Expression.Parameter(typeof(Product), "p");
        var prop = Expression.Property(prm, typeof(Product), propertyName);
        var lambda = Expression.Lambda<Func<Product, TKey>>(prop, "p", new[] { prm });
        return lambda;
    }
    static Expression<Func<Product, bool>> GetWhereExpression(string propertyName, object value)
    {
        var prm = Expression.Parameter(typeof(Product), "p");
        var prop = Expression.Property(prm, typeof(Product), propertyName);
        var equal = Expression.Equal(prop, Expression.Constant(value));
        var lambda = Expression.Lambda<Func<Product, bool>>(equal, "p", new[] { prm });
        return lambda;
    }
