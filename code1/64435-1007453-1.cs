	public class HomeController : ApplicationController
	{
		public HomeController(ILogger logger) : base(logger)
		{
		}
		public ActionResult Index()
		{
			_logger.Log("Home controller constructor started.");
			ViewData["Message"] = "Welcome to ASP.NET MVC!";
			return View();
		}
		public ActionResult About()
		{
			return View();
		}
	}
