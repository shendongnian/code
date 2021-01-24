    [HttpPost]
    [ValidateAntiForgeryToken]
    //Change the type of the object bound from the from 
    public ActionResult CourseSearchView(CourseSearchModel vm)
    {
        //Query the db and put the outcome in the results prop of the vm
        vm.results = QueryTheDb();
        //return the vm to the view
        return View(vm);
    }
