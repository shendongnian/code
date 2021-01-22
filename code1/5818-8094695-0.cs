	public class RouteHandler : IRouteHandler
	{
		public IHttpHandler 
		GetHttpHandler(RequestContext requestContext)
		{
			var request = requestContext.HttpContext.Request;
			// Here you should probably make the 'Views' directory appear in the correct place.
			var path = request.MapPath(request.Path); 
			if(File.Exists(path)) {
				// This is internal, you probably should make your own version.
				return new StaticFileHandler(requestContext);
			}
			else {
				return new MvcHandler(requestContext);
			}
		}
	}
