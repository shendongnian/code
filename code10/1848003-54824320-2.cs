            RouteTable.Routes.Add("testpng", new Route("testpng", new CustomRouteHandler(string.Format("~/test.png"))));
.
    public class CustomRouteHandler: IRouteHandler
    {
        string _virtualPath;
        public CustomRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.ContentType = GetContentType(_virtualPath);
            string filepath = requestContext.HttpContext.Server.MapPath(_virtualPath);
            requestContext.HttpContext.Response.WriteFile(filepath);
            requestContext.HttpContext.Response.End();
            return null;
        }
        private static string GetContentType(String path)
        {
            switch (System.IO.Path.GetExtension(path))
            {
                case ".pdf": return "application/pdf";
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: return "text/html";
            }
            //return "";
        }
    }
