    public ActionResult EntityRecords(string entityTypeName)
    {
        var entityProperty = context.GetType().GetProperty(entityTypeName);
        var entityQueryObject = (IQueryable)entityProperty.GetValue(context);
        var entityResults = entityQueryObject.Cast<object>().ToList();
        return View(entityResults);
    }
