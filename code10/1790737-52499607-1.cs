     public ActionResult Index()
        {
            Test objTest= new Test();
            objTest.EmployeeName = "Test";
            return View(objTest);
        }
      public ActionResult Save(Test obj)
        {
            return View("About");
        }
 
