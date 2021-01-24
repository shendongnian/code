     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
     {
        //Expose OData entities
        IEdmModel model = GetEdmModel(app.ApplicationServices);
           
        // This is use to define the route for your service, in this case it will be http://localhost:5000/someservice
        app.UseMvc(routeBuilder => routeBuilder.MapODataServiceRoute("odata", "someservice", model));
     }
     private static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
     {
         var builder = new ODataConventionModelBuilder(serviceProvider);
         //Expose the entity Client and allow to filter, orderby, page, expand and select
         builder.EntitySet<Client>(nameof(Client)).EntityType.Count().Filter().OrderBy().Page().Expand(ExpandMaxDepth).Select();
         builder.EntitySet<Address>(nameof(Address)).EntityType.Count().Filter().OrderBy().Page().Expand(ExpandMaxDepth).Select();
         [...]
         return builder.GetEdmModel();
     }
