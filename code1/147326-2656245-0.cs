    public ActionResult SearchDone(string query)
    {
        return Json(new 
        { 
            isDone = !isCached(query), 
            result = Cache.Get(query) 
        });
    }
