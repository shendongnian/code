    public ActionResult EntityRecords(string entityTypeName)
    {
        var entityProperty = context.GetType().GetProperty(entityTypeName);
        var entityQueryObject = entityProperty.GetValue(context);
        var entityResults = (IEnumerable<object>)Enumerable.ToList((dynamic)entityQueryObject);
        return View(entityResults);
    }
