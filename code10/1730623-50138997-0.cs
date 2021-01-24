    public List<object> GetAllEntities(MyContext db)
    {
        var results = new List<object>();
        results.AddRange(db.Customers.ToList());
        results.AddRange(db.Providers.ToList());
        results.AddRange(db.Products.ToList());
        return results;
    }
