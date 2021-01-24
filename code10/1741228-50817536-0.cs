        public abstract class BaseViewModelValidator<TModel> : IAsyncActionFilter
        where TModel : class
    {
        public async virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // get the model to validate
            if (context.ActionArguments["model"] is TModel model)
                await this.ValidateAsync(model, context.ModelState);
            else
                throw new Exception($"View model of type `{context.ActionArguments["model"].GetType()}` found, type of `{typeof(TModel)}` is required.");
            await next();
        }
        public abstract Task ValidateAsync(TModel model, ModelStateDictionary state);        
    }
