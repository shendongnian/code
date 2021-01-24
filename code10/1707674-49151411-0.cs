    public class CommonViewBagInitializerActionFilter : ActionFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
    #if DEBUG
			((BaseController)context.Controller).ViewBag.RootBlobURL = "";
    #else
			((BaseController)context.Controller).ViewBag.RootBlobURL = "https://blob.mysite.com";
    #endif
		}
	}
