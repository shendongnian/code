    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(FormCollection collection)
    {
      var filterType =  Request.Form["FilterSelect"];
      ViewData["FilterChosen"] = filterType;
      PopulateSelectionFiltersData();//This method fills up the drop down list
      
      string userControl = "DefaultControl";
      switch (filterType)
      {
          case "TypeA":
             userControl = "TypeAControl";
             break;
          ...
      }
    
      ViewData["SelectedControl"] = userControl; 
      return View();
    }
     <%= Html.RenderPartial( ViewData["SelectedControl"], Model, ViewData ) %>
