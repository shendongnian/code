    [Route("api/[controller]")]
        public class HomeController : BaseController
        {
          [HttpGet("[action]")]
            public IActionResult Index() => View();
         
           [HttpGet("[action]")]
            public IActionResult Error() => View();
    
    
           [HttpGet("[action]/{name}")]
            public IActionResult Detail(string name)
            {
                return RedirectToAction(nameof(Index));
            }
        }
