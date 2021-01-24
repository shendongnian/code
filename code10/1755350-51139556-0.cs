    public class NamespaceFilterConstraint : System.Web.Http.Routing.IHttpRouteConstraint
    {
        private Type[] types;
        public string[] AllowedNamespaces { get; }
        public NamespaceFilterConstraint(string[] ns)
        {
            AllowedNamespaces = ns;
            types = Assembly.GetExecutingAssembly().GetTypes();
        }
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            var controllerName = values["controller"] + "Controller";
            //This assumes no controllers with the same name in different namespaces
            Type controllerType = types.FirstOrDefault(t => t.Name == controllerName);
            return AllowedNamespaces.Contains(controllerType.Namespace);
        }
    }
