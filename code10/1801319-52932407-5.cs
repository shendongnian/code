    public ActionResult EntityRecords(string entityTypeName, FilterOptions options)
    {
        var entityProperty = context.GetType().GetProperty(entityTypeName);
        var entityQueryObject = entityProperty.GetValue(context);
        var entityResults = ApplyFiltersAndSuch((IQueryable)entityQueryObject);
        return View(entityResults);
    }
    private IEnumerable<object> ApplyFiltersAndSuch(IQueryable query, FilterOptions options)
    {
        var dynamicFilterString = BuildDynamicFilterString(options);
        return query.Where(dynamicFilterString)
            // you can add .OrderBy... etc.
            .Cast<object>()
            .ToList();
    }
