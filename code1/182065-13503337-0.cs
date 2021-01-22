    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class ParameterNameMapAttribute : ActionFilterAttribute
	{
		public string InboundParameterName { get; set; }
		public string ActionParameterName { get; set; }
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			object value = filterContext.RequestContext.HttpContext.Request[InboundParameterName];
			if (filterContext.ActionParameters.ContainsKey(ActionParameterName))
			{
				filterContext.ActionParameters[ActionParameterName] = value;
			}
			else
			{
				throw new Exception("Parameter not found on controller: " + ActionParameterName);
			}
		}
	}
