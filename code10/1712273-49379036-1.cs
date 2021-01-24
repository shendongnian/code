    internal class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                    new ApiError(
                        string.Join(" ",
                            context.ModelState.Values
                                .SelectMany(e => e.Errors)
                                .Select(e => e.ErrorMessage))));
            }
        }
    }
