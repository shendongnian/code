     public static class SwaggerExtensions
    {
        public static HttpConfiguration EnableSwagger(this HttpConfiguration httpConfiguration)
        {
            httpConfiguration
                .EnableSwagger(c => c.SingleApiVersion("v1", "WebApi"))
                .EnableSwaggerUi();
            return httpConfiguration;
        }
    }
