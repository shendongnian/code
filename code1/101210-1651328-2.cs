    public class SearchController 
    {
      public ActionResult Query(string q) 
      {
        Session("searchresults") = performSearch();
        return Json(new { ResultsUrl = 'Results'});
      }
      public ActionResult Results()
      {
        return View(Session("searchresults"));
      }
    }
