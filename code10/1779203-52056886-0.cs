    public class FromHeaderAttributeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            foreach (var httpParameterDescriptor in apiDescription.ActionDescriptor.GetParameters().Where(e => e.GetCustomAttributes<FromHeaderAttribute>().Any()))
            {
                var parameter = operation.parameters.Single(p => p.name == httpParameterDescriptor.ParameterName);
                parameter.name = httpParameterDescriptor.GetCustomAttributes<FromHeaderAttribute>().Single().HeaderName;
                parameter.@in = "header";
            }
        }
    }
