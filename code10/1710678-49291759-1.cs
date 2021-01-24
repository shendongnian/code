    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var entityConfig in ControllerEntity.EntityTypes)
            {
                var entityType = entityConfig;
                var typeName = entityType.Name + "Controller";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    var controllerType = typeof(GenericController<>)
                        .MakeGenericType(entityType)
                        .GetTypeInfo();
    
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
