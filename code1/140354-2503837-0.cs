    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult MyControllerMethod(string itemX, string itemY)
    {
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult MyControllerMethod(MyViewDataObject data)
    {
    }
