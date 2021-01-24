    public static class SwaggerMiddlewareExtensions
    {
        private static readonly string[] DefaultSwaggerTags = new[]
        {
            Resources.SwaggerMiddlewareExtensions_DefaultSwaggerTag
        };
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "My API",
                        Version = "v 1.0"
                    });
                    // your custom config
                    // this will group actions by localized name set in controller's DisplayAttribute
                    options.TagActionsBy(GetSwaggerTags);
                    
                    // this will add localized description to actions set in action's DisplayAttribute
                    options.OperationFilter<DisplayOperationFilter>();
                });
        }
        private static string[] GetSwaggerTags(ApiDescription description)
        {
            var actionDescriptor = description.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor == null)
            {
                return DefaultSwaggerTags;
            }
            var displayAttributes = actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (displayAttributes == null || displayAttributes.Length == 0)
            {
                return new[]
                {
                    actionDescriptor.ControllerName
                };
            }
            var displayAttribute = (DisplayAttribute)displayAttributes[0];
            return new[]
            {
                displayAttribute.GetName()
            };
        }
    }
where `DisplayOperationFilter` is:
    internal class DisplayOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor == null)
            {
                return;
            }
            var displayAttributes = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (displayAttributes == null || displayAttributes.Length == 0)
            {
                return;
            }
            var displayAttribute = (DisplayAttribute)displayAttributes[0];
            operation.Description = displayAttribute.GetDescription();
        }
    }
Applicable for Swashbuckle 5.
