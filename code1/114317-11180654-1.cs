    public class UriConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (typeof(Uri).IsAssignableFrom(instance.Property.PropertyType))
                instance.CustomType<UriType>();
        }
    }
