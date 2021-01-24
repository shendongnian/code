    public class RouteConfig : IMvcRouteMapper {
        public void RegisterRoutes(DotNetNuke.Web.Mvc.Routing.IMapRoute mapRouteManager) {
            mapRouteManager.MapRoute("ModuleNameHere", "ControllerNameHere", "{controller}/{action}", new[]
            {"ControllerNamespaceHere.Controllers"});
        }
    }
