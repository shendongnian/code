    namespace DL.SO.Web.UI.Extensions
    {
        public static class MvcBuilderExtensions
        {
            public static void AddFluentValidationServices(this IMvcBuilder mvcBuilder)
            {
                mvcBuilder.AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>();
                });
            }
        }
    }
