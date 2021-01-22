    public ActionResult Done(string query)
    {
        return Json(new 
        { 
            isDone = !isCached(query), 
            result = Cache.Get(query) 
        });
    }
