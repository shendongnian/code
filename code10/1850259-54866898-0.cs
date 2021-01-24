    public static partial class MvcBuilderExtensions
    {
        public static IMvcBuilder ConfigureExternalAttributes(this IMvcBuilder builder, ExternalValidationAttributeConfiguration attributeConfiguration = null)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            builder.Services.Configure<MvcOptions>(o => {
                o.Filters.Add(typeof(ExternalValidationActionFilterAttribute));
            });
            // add default configuration
            if (attributeConfiguration == null)
                attributeConfiguration = new ExternalValidationAttributeConfiguration();
            builder.Services.AddSingleton<ExternalValidationAttributeConfiguration>(attributeConfiguration);
            return builder;
        }
    }
