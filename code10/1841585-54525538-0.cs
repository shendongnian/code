    namespace Testy20161006.Controllers
    {
        //I'm showing how to pass data from one Controller Action to another Controller Action.
        //With the data you can render your second view however you like with the data.
        //We pass data NOT views.  You could use a partial view, but I am showing the most basic way.
        public class NewbieDevViewModel
        {
            public String DataToPassToNewControllerAction { get; set; }
        }
        public class HomeController : Controller
        {
            //I am using Tut145 for my first Controller/Action/View, but you could have called it Index
            [HttpPost]
            public ActionResult Tut145(NewbieDevViewModel passedData)
            {
                //passing simple string, so I can pass it using my QueryString
                return RedirectToAction("MyAction2", "Home2", new { passedData = passedData.DataToPassToNewControllerAction });
            }
            public ActionResult Tut145()
            {
                return View();
            }
