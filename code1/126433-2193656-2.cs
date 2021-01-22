    public ActionResult Bar()
    {
      return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public void Bar(string address)
    {
    //code to update address
    }
