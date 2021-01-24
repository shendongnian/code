    public class CustomValidationResponseActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var modelState in context.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                var responseObj = new
                {
                    code = 400,
                    request_id = "dfdfddf",
                    messages = errors
                };
                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = 400
                };
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
