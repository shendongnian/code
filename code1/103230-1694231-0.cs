    XElement filters = ...; // the "Filters" element
    IQueryable<Customer> query = ...; // your raw (unfiltered) query
    foreach(var filter in filters.Elements("Add")) {
        var param = Expression.Parameter(typeof(Customer), "row");
        var body = Expression.Equal(
            Expression.PropertyOrField(param, (string)filter.Attribute("Prop")),
            Expression.Constant(filter.Value, typeof(string)));
        query = query.Where(Expression.Lambda<Func<Customer, bool>>(
            body, param));
    }
