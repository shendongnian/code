    public ActionResult Foo()
    {
      return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public void Foo(string address)
    {
    //code to update address
    }
