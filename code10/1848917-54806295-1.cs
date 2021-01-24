    [Route("api/[controller]")]
        public class HomeController : BaseController
        {
          [Route("[action]")]
            public IActionResult Index() => View();
         
           [Route("[action]")]
            public IActionResult Error() => View();
    
    
           [Route("[action]/{name}")]
            public IActionResult Detail(string name)
            {
                return RedirectToAction(nameof(Index));
            }
        }
