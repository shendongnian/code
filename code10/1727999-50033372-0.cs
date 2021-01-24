    public class HomeController : Controller
    {
        public ActionResult Phone()
        {
            Response.Redirect("tel:5551212");
            return new EmptyResult();
        }
    }
