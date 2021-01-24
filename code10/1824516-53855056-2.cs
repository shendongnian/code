	public class HomeController : Controller
	{
		private IHostingEnvironment _env;
		public HomeController(IHostingEnvironment env)
		{
			_env = env;
		}
		   
		public ActionResult MyAction()
		{
			var folderPath = System.IO.Path.Combine(_env.ContentRootPath, "/images_upload");
			var model = new MyViewModel()
			{
				Images = Directory.EnumerateFiles(folderPath)
                    .Select(filename => folderPath + filename)
			};
			return View(model);
		}
	}
