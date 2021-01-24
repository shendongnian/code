    public class AuthTokenOperation : IDocumentFilter
        {
            /// <summary>
            /// Apply custom operation.
            /// </summary>
            /// <param name="swaggerDoc">The swagger document.</param>
            /// <param name="schemaRegistry">The schema registry.</param>
            /// <param name="apiExplorer">The api explorer.</param>
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                swaggerDoc.paths.Add("/token", new PathItem
                {
                    post = new Operation
                    {
                        tags = new List<string> { "Auth"},
                        consumes = new List<string>
                        {
                            "application/x-www-form-urlencoded"
                        },
                        parameters = new List<Parameter>
                        {
                            new Parameter
                            {
                                type = "string",
                                name = "grant_type",
                                required = true,
                                @in = "formData"
                            },
                            new Parameter
                            {
                                type = "string",
                                name = "username",
                                required = false,
                                @in = "formData"
                            },
                            new Parameter
                            {
                                type = "string",
                                name = "password",
                                required = false,
                                @in = "formData"
                            },
                        }
                    }
                });
            }
        }
