     public class ScrubbingModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (!context.Metadata.IsComplexType&&context.Metadata.PropertyName!=null)
            {
                // Look for scrubber attributes
                var propName = context.Metadata.PropertyName;
                var propInfo = context.Metadata.ContainerType.GetProperty(propName);
                // Only one scrubber attribute can be applied to each property
                var attribute = propInfo.GetCustomAttributes(typeof(IScrubberAttribute), false).FirstOrDefault();
                if (attribute != null)
                    return new ScrubbingModelBinder(context.Metadata.ModelType, attribute as IScrubberAttribute);
            }
            return null;
        }
    }
