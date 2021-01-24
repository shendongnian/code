    public class ValidateModelFilter : Attribute, IAsyncResultFilter
        {
            public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
            {
                if (!context.ModelState.IsValid)
                    throw new InvalidParametersException(context.ModelState.StringErrors());
    
                await next();
            }
        }
