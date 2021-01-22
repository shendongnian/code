     double result = new
        Select(Aggregate.Avg("UnitPrice"))
        .From(Product.Schema)
        .ExecuteScalar<double>();
     IDataReader reader = new
        Select(Aggregate.GroupBy("ProductID"), Aggregate.Avg("UnitPrice"))
        .From("Order Details")
        .Where(Aggregate.Avg("UnitPrice"))
        .IsGreaterThan(50)
        .ExecuteReader();
