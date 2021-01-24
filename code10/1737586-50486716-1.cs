    public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                [...]
                config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Backend.WebApi"))
                .EnableSwaggerUi();
