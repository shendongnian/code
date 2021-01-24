    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Redirect), new { width = 20, height = 40 } } );
        }
    
        public IActionResult Redirect(decimal width, decimal height)
        {
            RedirectViewModel viewModel = new RedirectViewModel()
            {
               // Populate view model here with width and height
            }
            return View(viewModel);
        }
    }
