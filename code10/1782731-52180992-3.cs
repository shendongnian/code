    namespace App.Controllers
    {
        [ApiController]
        [Route("Hello")]
        public class HelloController : Controller
        {
            [MyFilter]
            [HttpGet("index")]
            public IActionResult Index(int x)
            {
                var y =ModelState.IsValid;
                return View();
            }
        }
    }
