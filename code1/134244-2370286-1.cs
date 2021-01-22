    public class ExampleRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string page = requestContext.RouteData.GetRequiredString("Parameter");
    
            if (page == "") {
                page = "default";
            }
    
            string @virtual = string.Format("~/example/{0}.aspx", page);
    
            return (Page)BuildManager.CreateInstanceFromVirtualPath(@virtual, typeof(Page));
        }
    }
