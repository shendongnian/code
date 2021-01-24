    public class HomeController : Controller
    {
        public IActionResult Index(string name)
        {
            return new JsonResult(new {
                Name=name
            });
        }
        [HttpPost]
        public IActionResult Person([Bind("Age,Name")]MyModel model)
        {
            return new JsonResult(model);
        }
    }
