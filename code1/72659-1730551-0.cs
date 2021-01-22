    public class ImageRouteHandler:IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                string filename = requestContext.RouteData.Values["filename"] as string;
    
                return new ImageHttpHandler(filename);
    
            }
        } 
