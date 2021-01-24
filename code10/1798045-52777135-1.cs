    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
    
            var additionalAttribute = attributes.OfType<DisplayWhenAttribute>().FirstOrDefault();
    
            if (additionalAttribute != null)
            {
                metadata.AdditionalValues.Add("DisplayWhenAttribute", additionalValues);
            }
    
            return metadata;
        }
    }
