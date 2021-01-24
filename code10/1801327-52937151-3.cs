    public ActionResult EntityRecords(string entityType)
    {
        var type = Type.GetType(entityType);
        var entityResults = context.Set(type).ToList();
        return View(entityResults);
    }
