    public class AjaxRedirectResult : RedirectResult
	{
		public AjaxRedirectResult(string url, ControllerContext controllerContext)
			: base(url)
		{
			ExecuteResult(controllerContext);
		}
		public override void ExecuteResult(ControllerContext context)
		{
			if (context.RequestContext.HttpContext.Request.IsAjaxRequest())
			{
				JavaScriptResult result = new JavaScriptResult()
				{
					Script = "try{history.pushState(null,null,window.location.href);}catch(err){}window.location.replace('" + UrlHelper.GenerateContentUrl(this.Url, context.HttpContext) + "');"
				};
				result.ExecuteResult(context);
			}
			else
			{
				base.ExecuteResult(context);
			}
		}
	}
