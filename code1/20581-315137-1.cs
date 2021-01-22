    public ActionResult List()
    {
        List<string> myList = database.GetListOfStrings();
        (...)
        return View("List", myList);
    }
    
