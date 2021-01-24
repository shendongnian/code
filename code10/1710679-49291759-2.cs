    public class GenericControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() != typeof(GenericController<>))
            {
                return;
            }
    
            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name + "Controller";
            controller.RouteValues["Controller"] = entityType.Name;
        }
    }
