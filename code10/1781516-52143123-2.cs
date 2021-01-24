    public class BodyOrForm : IModelBinder
    {
        private readonly IModelBinderFactory factory;
        public BodyOrForm(IModelBinderFactory factory)
        {
            this.factory = factory;
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var contentType = bindingContext.ActionContext.HttpContext.Request.ContentType;
            BindingInfo bindingInfo = new BindingInfo();
            if (contentType == "application/json")
            {
                bindingInfo.BindingSource = BindingSource.Body;
            }
            else if (contentType == "application/x-www-form-urlencoded")
            {
                bindingInfo.BindingSource = BindingSource.Form;
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            var binder = factory.CreateBinder(new ModelBinderFactoryContext
            {
                Metadata = bindingContext.ModelMetadata,
                BindingInfo = bindingInfo,
            });
            await binder.BindModelAsync(bindingContext);
        }
    }
