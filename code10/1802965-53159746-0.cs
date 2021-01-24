    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CheckRequiredParmAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requiredParameters = context.ActionDescriptor.Parameters.Where(
                p => ((ControllerParameterDescriptor)p).ParameterInfo.GetCustomAttribute<RequiredParmAttribute>() != null).Select(p => p.Name);
            foreach (var parameter in requiredParameters)
            {
                if (!context.ActionArguments.ContainsKey(parameter))
                {
                    context.ModelState.AddModelError(parameter, $"The required argument '{parameter}' was not found.");
                }
                else
                {
                    foreach (var argument in context.ActionArguments.Where(a => parameter.Equals(a.Key)))
                    {
                        if (argument.Value == null)
                        {
                            context.ModelState.AddModelError(argument.Key, $"The requried argument '{argument.Key}' cannot be null.");
                        }
                    }
                }
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
    /// <summary>
    /// Use this attribute to force a [FromQuery] parameter to be required. If it is missing, or has a null value, model state validation will be executed and returned throught the response. 
    /// </summary>  
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class RequiredParmAttribute : Attribute
    {
    }
