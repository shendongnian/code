    public class RoutingControllerModelConvention : IControllerModelConvention
    {
        private readonly IConfiguration _configuration;
        public RoutingControllerModelConvention(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Apply(ControllerModel controllerModel)
        {
            const string RouteTemplate = "/api/projects/<id>/[action]";
            var routeId = _configuration["RouteIds:" + controllerModel.ControllerName];
            var firstSelector = controllerModel.Selectors[0];
            if (firstSelector.AttributeRouteModel == null)
                firstSelector.AttributeRouteModel = new AttributeRouteModel();
            firstSelector.AttributeRouteModel.Template = RouteTemplate.Replace("<id>", routeId);
        }
    }
