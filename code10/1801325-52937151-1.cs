    public ActionResult EntityRecords(string entityType)
    {
        var entityResults = context.Set(Type.GetType(entityType)).ToList();
        return View(entityResults);
    }
