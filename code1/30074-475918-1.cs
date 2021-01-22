    public class CustomerController : Controller
    
    ...
    
    public ActionResult Search(int id)
    {
     ViewData["SearchResult"] = MySearchBLL.GetSearchResults(id);
     
     return View("Index");
    }
    
    ...
