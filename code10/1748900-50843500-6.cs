    public class BeaconController : Controller
    {
        [Route("Beacon/{id?}")]
        public ActionResult Index(int? id)
        {
            if(id!=null)
            {
                return Content(id.Value.ToString());
            }
            return Content("Id missing");
        }
    }
