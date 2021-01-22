    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult GetItemsForJson()
    {
        var items = Repository.GetItems();
        var result = Json(items);
        
        return result;
    }
