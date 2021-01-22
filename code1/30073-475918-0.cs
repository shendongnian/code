    public class CustomerController : Controller
    
    ...
    
    public ActionResult Search(int id)
    {
     ViewData["SearchResult"] = MySearchBLL.GetSearchResults(id);
     
     Return View("Index");
    }
    
    ...
