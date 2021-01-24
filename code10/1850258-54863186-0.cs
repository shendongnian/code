    
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class ExternalConfigurationExtensions
        {
            public static IMvcBuilder ConfigureExternalControllers(this IMvcBuilder builder)
            {
                if (builder == null)
                    throw new ArgumentNullException(nameof(builder));
    
                builder.AddApplicationPart(typeof(ExternalController).Assembly);
    
                return builder;
            }
        }
    }
