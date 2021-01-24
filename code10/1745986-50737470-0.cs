     .EnableSwaggerUi(c =>
                    {
                    
                        c.InjectJavaScript(thisAssembly, "ProjectScavengerAPI.Web.Scripts.Swagger.jwt-auth.js");
                        c.EnableApiKeySupport("Authorization", "header");
                                            });
