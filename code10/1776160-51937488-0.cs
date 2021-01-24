    public class InstanceController : Controller
    {
       public ActionResult Details(int id)
       {
          return Content("Details of "+id);
          // to do : return a view with data queried using id
       }
    }
