    namespace Solution.Areas.ControlPanel.Controllers
    {
        [Area(nameof(ControlPanel))]
        [Route(nameof(ControlPanel) + "/[controller]")]
        public class HomeController : Controller
        {
            public IActionResult Index() => View();
        }
    }
