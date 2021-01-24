    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect(new Size() { Width = 20, Height = 40 } );
        }
    
        public IActionResult Redirect([FromRoute] Size size)
        {
            return View(size);
        }
    }
