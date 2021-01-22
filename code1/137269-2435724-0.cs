    public class ApiController : Controller {        
    
            public ActionResult Index(string id) {
    
                var xml = new XElement("results", 
                                new XAttribute("myId", id ?? "null"));
    
                return Content(xml.ToString(), "text/xml");
            }
    
        }
