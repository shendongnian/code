        public class ActionParameterValidationAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                actionContext
                    .ActionDescriptor
                    .GetParameters()
                    .SelectMany(p => p.GetCustomAttributes<ValidationAttribute>().Select(a => new
                    {
                        IsValid = a.IsValid(actionContext.ActionArguments[p.ParameterName]),
                        p.ParameterName,
                        ErrorMessage = a.FormatErrorMessage(p.ParameterName)
                    }))
                    .Where(_ => !_.IsValid)
                    .ToList()
                    .ForEach(_ => actionContext.ModelState.AddModelError(_.ParameterName, _.ErrorMessage));
                if (!actionContext.ModelState.IsValid)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                }
            }
        }
