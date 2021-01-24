    public ActionResult Index()
    {
        Console.WriteLine("Redirected To Index");
        return View("add actual path of the view", model); 
        //For Example
        //return View("~/Views/Test/Login.cshtml", model); 
    }
