    public class HomeController : BaseController
            {
                public IActionResult Index() => View();
             
                public IActionResult Error() => View();
        
        
                [HttpGet("api/[controller]/{name}")]
                public IActionResult Detail(string name)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
