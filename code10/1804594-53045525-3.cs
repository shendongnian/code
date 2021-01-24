    public class HomeController : Controller
            {
                public JsonResult ButtonPressed()
                {
                    MvcApplication.CancelLoop();
        
                    return Json("canceled", JsonRequestBehavior.AllowGet);
                }
            }
