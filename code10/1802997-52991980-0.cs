    public static void Register(HttpConfiguration config)
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        //Declare entities
        builder.EntitySet<Empleado>("Empleados");
        //Define verion
        Version odataVersion2 = new Version(2, 0);
        builder.DataServiceVersion = odataVersion2;
        builder.MaxDataServiceVersion = odataVersion2;
        IEdmModel edmModel = builder.GetEdmModel();
        edmModel.SetEdmVersion(odataVersion2);
        edmModel.SetEdmxVersion(odataVersion2);
        
        config.Routes.MapODataServiceRoute("odata", "odata", edmModel);
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
