    public class VerifyAccessFilterAttribute : Attribute, IActionModelConvention, IResourceFilter
    {
        public VerifyAccessFilterAttribute(params string[] routeTemplates)
        {
            RouteTemplates = routeTemplates;
        }
        public string[] RouteTemplates { get; set; }
        public void Apply(ActionModel actionModel)
        {
            actionModel.Selectors.Clear();
            foreach (var routeTemplate in RouteTemplates)
            {
                actionModel.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel { Template = routeTemplate },
                    ActionConstraints = { new HttpMethodActionConstraint(new[] { "GET" }) }
                });
            }
        }
        public void OnResourceExecuting(ResourceExecutingContext ctx) { ... }
        public void OnResourceExecuted(ResourceExecutedContext ctx) { ... }
    }
