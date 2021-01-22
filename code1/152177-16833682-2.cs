    using System;
    using System.Web;
    using System.Web.Routing;
    using System.Web.Services.Protocols;
    public class ServiceRouteHandler : IRouteHandler
    {
        private readonly string _virtualPath;
        private readonly WebServiceHandlerFactory _handlerFactory = new WebServiceHandlerFactory();
        public ServiceRouteHandler(string virtualPath)
        {
            if( virtualPath == null )
                throw new ArgumentNullException("virtualPath");
            if( !virtualPath.StartsWith("~/") )
                throw new ArgumentException("Virtual path must start with ~/", "virtualPath");
            _virtualPath = virtualPath;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // Note: can't pass requestContext.HttpContext as the first parameter because that's
            // type HttpContextBase, while GetHandler wants HttpContext.
            return _handlerFactory.GetHandler(HttpContext.Current, requestContext.HttpContext.Request.HttpMethod, _virtualPath, requestContext.HttpContext.Server.MapPath(_virtualPath));
        }
    }
