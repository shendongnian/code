    public class QueryStringFilterAttribute : ActionFilterAttribute
	{
		public string ParameterName { get; private set; }
		public QueryStringFilterAttribute(string parameterName)
		{
			if(string.IsNullOrEmpty(parameterName))
				throw new ArgumentException("ParameterName is required.");
			ParameterName = parameterName;
		}
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var qs = new FormCollection(filterContext.HttpContext.Request.QueryString);
			filterContext.ActionParameters[ParameterName] = qs;
			base.OnActionExecuting(filterContext);
		}
	}
