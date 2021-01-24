    namespace Testy20161006.Controllers
    {
        public class MyData
        {
            public string NeoData { get; set; }
        }
        public class HomeController : Controller
        {
            [HttpPost]
            //adding generic ActionResult to Task type
            public async Task<ActionResult> Progess(MyData mydata)
            {
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> AddData(MyData mydata)
            {
                return View("AddDetails", mydata);
            }
            public ActionResult Tut137()
            {
                MyData myData = new MyData { NeoData = "neoData" };
                return View(myData);
            }
