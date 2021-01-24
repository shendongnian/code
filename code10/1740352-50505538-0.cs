    public class ModelStateErrorHandlingFilter : IAsyncActionFilter {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if (!context.ModelState.IsValid) {
                var model = new {
                    Error = context.ModelState
                        .SelectMany(keyValuePair => keyValuePair.Value.Errors)
                        .Select(modelError => modelError.ErrorMessage)
                        .ToArray()
                };
                context.Result = new ObjectResult(model) {
                    StatusCode = 400
                };
            } else {
                await next().ConfigureAwait(false);
            }
        }
    }
