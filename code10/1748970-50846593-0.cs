    public class CustomSchemaFilters : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            var excludeProperties = new[] {"name", "lastname, "token"};
    
            foreach(var prop in excludeProperties)
                if (schema.properties.ContainsKey(prop))
                    schema.properties.Remove(prop);
        }
    }
