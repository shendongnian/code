            app.UseMvc(options =>
            {
                var model = builder.GetEdmModel();
                options
                    .MapODataServiceRoute(
                        "odata",
                        "odata",
                        b => b
                                .AddService(Microsoft.OData.ServiceLifetime.Scoped, s => model)
                                .AddService<IEnumerable<IODataRoutingConvention>>(
                                    Microsoft.OData.ServiceLifetime.Scoped,
                                    s => ODataRoutingConventions.CreateDefaultWithAttributeRouting("odata", options))
                                .AddService<ODataSerializerProvider, CustomODataSerializerProvider>(Microsoft.OData.ServiceLifetime.Singleton));
            }
