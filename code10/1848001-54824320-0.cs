            RouteTable.Routes.Add("testpng", new Route("testpng", new ImageRouteHandler(string.Format("~/test.png"))));
.
    public class ImageRouteHandler : IRouteHandler
    {
        string _virtualPath;
        public ImageRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.ContentType = GetContentType(requestContext.HttpContext.Request.Url.ToString());
            string filepath = requestContext.HttpContext.Server.MapPath(_virtualPath);
            requestContext.HttpContext.Response.WriteFile(filepath);
            requestContext.HttpContext.Response.End();
            return null;
        }
        private static string GetContentType(String path)
        {
            switch (System.IO.Path.GetExtension(path))
            {
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }
    }
