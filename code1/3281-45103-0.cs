		[NavigationLocationFilter("Products")]
		public ViewResult List()
		{
			return View();
		}
...
	public class NavigationLocationFilterAttribute : ActionFilterAttribute
	{
		public string CurrentLocation { get; set; }
		public NavigationLocationFilterAttribute(string currentLocation)
		{
			CurrentLocation = currentLocation;
		}
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var controller = (Controller)filterContext.Controller;
			controller.ViewData.Add("NavigationLocation", CurrentLocation);
		}
	}
