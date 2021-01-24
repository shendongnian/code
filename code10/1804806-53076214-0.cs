     public ActionResult ReturnBobsStuff()
    {
    List<string> myList = new List<string> { "element1", "element2", 
                                             "element3", "element4", 
                                             "element5", 
                                           };
    ViewBag.MyVariable = myList.ToArray();
    return View();
    }
