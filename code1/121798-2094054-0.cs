	public class LegacyUrlRoute : RouteBase
	{
		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			const string status = "301 Moved Permanently";
			var request = httpContext.Request;
			var response = httpContext.Response;
			var legacyUrl = request.Url.ToString();
			var newUrl = "";
			var id = request.QueryString.Count != 0 ? request.QueryString[0] : "";
			if (legacyUrl.Contains("d.aspx"))
			{
				newUrl = "Dispute/Details/" + id;
				response.Status = status;
				response.RedirectLocation = newUrl;
				response.End();
			}
			return null;
		}
		public override VirtualPathData GetVirtualPath(RequestContext requestContext,
					RouteValueDictionary values)
		{
			return null;
		}
	}
    public static void RegisterRoutes(RouteCollection routes)
    {
        // all my other routes
        routes.Add(new LegacyUrlRoute());
    }
