    /// <summary>
        /// The class to add the authorization header.
        /// </summary>
        public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            /// <summary>
            /// Applies the operation filter.
            /// </summary>
            /// <param name="operation"></param>
            /// <param name="schemaRegistry"></param>
            /// <param name="apiDescription"></param>
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (operation.parameters != null)
                {
                    operation.parameters.Add(new Parameter
                    {
                        name = "Authorization",
                        @in = "header",
                        description = "access token",
                        required = false,
                        type = "string"
                    });
                }
            }
        }
