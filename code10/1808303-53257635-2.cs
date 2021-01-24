    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || (controller.ControllerType.GetGenericTypeDefinition() !=
                typeof(GenericController<>) && controller.ControllerType.GetGenericTypeDefinition() !=
                typeof(GenericSubNavigationController<,,>)))
            {
                // Not a GenericController, ignore.
                return;
            }
            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = $"{entityType.Name}";
            if (controller.ControllerType.GetGenericTypeDefinition() ==
                typeof(GenericSubNavigationController<,,>))
            {
                foreach (var controllerAction in controller.Actions)
                {
                    if (controllerAction.ActionName == "GetNavigation")
                    {
                        var subType = controller.ControllerType.GenericTypeArguments[1];
                        PropertyInfo propertyInfo = entityType.GetProperties().FirstOrDefault(x => x.PropertyType == subType);
                        controllerAction.ActionName = $"Get{propertyInfo.Name}";
                    }
                }
            }
        }
    }
