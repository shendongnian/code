    public ActionResult Create_Filter([DataSourceRequest] DataSourceRequest request, 
    [Bind(Prefix = "models")]IEnumerable<CourseFilterViewModel> courseFilterVM)
    {
        var results = new List<Results>
        {
            new Results {CourseNumber = "100", CourseTitle = "Test Title", 
             CourseSubject = "Subject Test"}
        };
        TempData["results"] = results;
        return RedirectToAction("TestView", "Filter");
     }
     public ActionResult TestView()
     {
                    
        if(TempData["results"] != null) {
          //do something
        }
        return whatever;
     }
