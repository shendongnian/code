    public ActionResult EntityRecords<TEntity>()
    {
        var entityResults = context.Set<TEntity>.ToList();
        return View(entityResults);
    }
