    [Route("[controller]")]
        public class HomeController : Controller
        {
            [HttpGet("[action]/{xxx}")]
            public IActionResult Privacy(string xxx)
            {
                return Content(xxx);
            }
        }
