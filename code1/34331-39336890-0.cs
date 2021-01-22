    public static class CustomAttributeExtractorExtensions
    {
        /// <summary>
        /// Extraction of property attributes as well as attributes on implemented interfaces.
        /// This will walk up recursive to collect any interface attribute as well as their parent interfaces.
        /// </summary>
        /// <typeparam name="TAttributeType"></typeparam>
        /// <param name="typeToReflect"></param>
        /// <returns></returns>
        public static List<PropertyAttributeContainer<TAttributeType>> GetPropertyAttributesFromType<TAttributeType>(this Type typeToReflect)
            where TAttributeType : Attribute
        {
            var list = new List<PropertyAttributeContainer<TAttributeType>>();
            
            // Loop over the direct property members
            var properties = typeToReflect.GetProperties();
            foreach (var propertyInfo in properties)
            {
                // Get the attributes as well as from the inherited classes (true)
                var attributes = propertyInfo.GetCustomAttributes<TAttributeType>(true).ToList();
                if (!attributes.Any()) continue;
                list.AddRange(attributes.Select(attr => new PropertyAttributeContainer<TAttributeType>(attr, propertyInfo)));
            }
            // Look at the type interface declarations and extract from that type.
            var interfaces = typeToReflect.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                list.AddRange(@interface.GetPropertyAttributesFromType<TAttributeType>());
            }
            return list;
        }
        /// <summary>
        /// Simple container for the Property and Attribute used. Handy if you want refrence to the original property.
        /// </summary>
        /// <typeparam name="TAttributeType"></typeparam>
        public class PropertyAttributeContainer<TAttributeType>
        {
            internal PropertyAttributeContainer(TAttributeType attribute, PropertyInfo property)
            {
                Property = property;
                Attribute = attribute;
            }
            public PropertyInfo Property { get; private set; }
            public TAttributeType Attribute { get; private set; }
        }
    }
