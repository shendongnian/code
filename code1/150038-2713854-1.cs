    public class HomeController : Controller
    {
        public ActionResult Update(string txtA, string txtB)
        {
            ViewData["result"] = txtA + txtB;
        }
    }
