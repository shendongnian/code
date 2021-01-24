    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerProducesAttribute : Attribute
    {
        public SwaggerProducesAttribute(params string[] contentTypes)
        {
            this.ContentTypes = contentTypes;
        }
        public IEnumerable<string> ContentTypes { get; }
    }
    public class ProducesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var attribute = apiDescription.GetControllerAndActionAttributes<SwaggerProducesAttribute>().SingleOrDefault();
            if (attribute == null)
            {
                return;
            }
            operation.produces.Clear();
            operation.produces = attribute.ContentTypes.ToList();
        }
    }
