    var query = db.Products.Where(p => p.CustomerId == customerId);
    if (predicate != null)
    {
        var parameter = Expression.Parameter(typeof(Product), "p");
        var body = Expression.Invoke(predicate, parameter);
        var newPredicate = Expression.Lambda<Func<Product, bool>>(body, parameter);
        query = query.Where(newPredicate);
    }
    return query.ToList();
