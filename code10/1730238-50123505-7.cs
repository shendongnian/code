    //Controller
    public class SearchController{
        [HttpGet]
        public ActionResult SearchBox(){
            return View();
        }
    
    
        [HttpPost]
        public ActionResult SearchBox(SearchViewModel model){
            //model is now populated with your values from your form.
            //ex: model.Query
    
            return View();
        }
    }
