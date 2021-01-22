    public class ValidateActionParametersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var parameters = context.ActionDescriptor.GetParameters();
            foreach (var parameter in parameters)
            {
                var argument = context.ActionArguments[parameter.ParameterName];
                EvaluateValidationAttributes(parameter, argument, context.ModelState);
            }
            base.OnActionExecuting(context);
        }
        private void EvaluateValidationAttributes(HttpParameterDescriptor parameter, object argument, ModelStateDictionary modelState)
        {
            var validationAttributes = parameter.GetCustomAttributes<ValidationAttribute>();
            foreach (var validationAttribute in validationAttributes)
            {
                if (validationAttribute != null)
                {
                    var isValid = validationAttribute.IsValid(argument);
                    if (!isValid)
                    {
                        modelState.AddModelError(parameter.ParameterName, validationAttribute.FormatErrorMessage(parameter.ParameterName));
                    }
                }
            }
        }
    }
