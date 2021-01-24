    public class ExternalControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        private readonly IExternalCompiler _entityCompiler;
        public ExternalControllerFeatureProvider(IExternalCompiler entityCompiler)
        {
            _entityCompiler = entityCompiler;
        }
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var types = _entityCompiler.GetTypes().ToList();
            foreach (var candidate in types)
            {
                feature.Controllers.Add(
                    typeof(GenericController<>).MakeGenericType(candidate).GetTypeInfo()
                );
                foreach (var propertyInfo in candidate.GetProperties())
                {
                    Type targetType = propertyInfo.PropertyType.GenericTypeArguments.Any()
                        ? propertyInfo.PropertyType.GenericTypeArguments.First()
                        : propertyInfo.PropertyType;
                    if (types.Contains(targetType))
                    {
                        var typeInfo = typeof(GenericSubNavigationController<,,>).MakeGenericType(candidate, propertyInfo.PropertyType, targetType).GetTypeInfo();
                        feature.Controllers.Add(typeInfo);
                    }
                }
            }
        }
    }
