    public class ApplySwaggerImplementationNotesFilterAttributes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var attr = apiDescription.GetControllerAndActionAttributes<SwaggerImplementationNotesAttribute>().FirstOrDefault();
            if (attr != null)
            {
                operation.description = attr.ImplementationNotes;
            }
        }
    }
    public class ApplySwaggerOperationSummaryFilterAttributes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var attr = apiDescription.GetControllerAndActionAttributes<SwaggerOperationSummaryAttribute>().FirstOrDefault();
            if (attr != null)
            {
                operation.summary = attr.OperationSummary;
            }
        }
    }
