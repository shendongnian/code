    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiDescriptionGroupCollectionProvider provider;
    
        public ConfigureSwaggerOptions(
            IApiDescriptionGroupCollectionProvider  provider ) => this.provider = provider;
    
        public void Configure( SwaggerGenOptions options )
        {
            // TODO: configure swashbuckler with plug-in information
        }
    }
