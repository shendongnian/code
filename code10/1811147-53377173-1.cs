    public class AddSwaggerRequiredSchemaFilter : ISchemaFilter
    {
        public void Apply(Swashbuckle.Swagger.Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(SwaggerRequiredAttribute));
                if (attribute != null)
                {
                    var propertyNameInCamelCasing = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);
                    if (schema.required == null)
                    {
                        schema.required = new List<string>()
                        {
                            propertyNameInCamelCasing
                        };
                    }
                    else
                    {
                        schema.required.Add(propertyNameInCamelCasing);
                    }
                }
            }
        }
    }
