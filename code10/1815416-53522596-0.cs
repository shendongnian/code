    public class Contains2RoutesAttribute : Attribute, IActionModelConvention, IResourceFilter
    {
        public void Apply(ActionModel action)
        {
            action.Selectors.Clear();
            // Adding route 1:
            action.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel { Template = "~/index1" }
            });
            // Adding route 2:
            action.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel { Template = "~/index2" }
            });
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        { }
        public void OnResourceExecuting(ResourceExecutingContext context)
        { }
    }
