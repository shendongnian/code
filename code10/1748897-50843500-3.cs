    public class BeaconController : Controller
    {
        public ActionResult Index(int? id)
        {
            if(id!=null)
            {
                return Content(id.Value.ToString());
            }
            return Content("Id missing");
    
        }
    }
