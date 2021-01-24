    public class SearchController{
        [HttpGet]
        public ActionResult SearchBox(SearchViewModel model){
            //if the model values are in the URL "model" will be populated, else it will be null.
            return View();
        }
    }
