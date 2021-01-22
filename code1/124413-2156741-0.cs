	public class AdminRouteHandler : IRouteHandler
	{
		private readonly IRouteHandler _mvcHandler = new MvcRouteHandler();
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var values = requestContext.RouteData.Values;
			if(values.ContainsKey("controller"))
				values["controller"] = "Admin" + values["controller"];
			return _mvcHandler.GetHttpHandler(requestContext);
		}
	}
