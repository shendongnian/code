    public class ValidIntegerRangeValidator : DataAnnotationsModelValidator<RangeAttribute>
    {
        public ValidIntegerRangeValidator(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)
            : base(metadata, context, attribute)
        {
            try
            {
                if (attribute.IsValid(context.HttpContext.Request.Form[metadata.PropertyName]))
                {
                    return;
                }                
            }
            catch (OverflowException)
            {
            }
            var propertyName = metadata.PropertyName;
            context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
            context.Controller.ViewData.ModelState[propertyName].Errors.Add(string.Format(Resources.Resources.FieldRangeValidation, attribute.Minimum, attribute.Maximum));
        }
    }
