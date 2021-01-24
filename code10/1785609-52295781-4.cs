    public class AccessLoadApiAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(HttpActionContext actionContext) {
            //get the resolver via the request context
            var resolver = actionContext.RequestContext.Configuration.DependencyResolver;
            //use resolver to get dependency
            ILoadServiceEntity _loadServiceEntity = (ILoadServiceEntity)resolver.GetService(typeof(ILoadServiceEntity));
            var loadId = Convert.ToInt32(actionContext.RequestContext.RouteData.Values["Id"]);
            _loadServiceEntity.GetLoadById(loadId);
            base.OnActionExecuting(actionContext);
        }
    }
