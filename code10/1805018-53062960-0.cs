	public class ControllerBase : Controller
	{
		protected Context _dbcontext;
	
		public ControllerBase()
		{
				
		}
		
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			ViewData[""] = _dbcontext.....
		}
	}
	public class MyController : ControllerBase
	{
		public HomeController(Context dbcontext)
		{
			_dbcontext = dbcontext
		}
	}
