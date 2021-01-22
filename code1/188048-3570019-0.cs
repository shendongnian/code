    public class TestController : Controller
    {
        public ActionResult Test(Test input)
        {
            string selected = input.YourDropDown; //Here is your value
    
            return View();
        }
    
    }
