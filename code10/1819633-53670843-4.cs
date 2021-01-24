    public class ServerErrorResponseOperationFilter : IOperationFilter
        {            
            // Applies the specified operation. Adds 500 ServerError to Swagger documentation for all endpoints            
            public void Apply(Operation operation, OperationFilterContext context)
            {
                // ensure we are filtering on controllers
                if (context.MethodInfo.DeclaringType.BaseType.BaseType == typeof(ControllerBase)
                    || context.MethodInfo.ReflectedType.BaseType == typeof(Controller))
                {
                    operation.Responses.Add("500", new Response { Description = "Server Error" });
                }                        
            }
        }
