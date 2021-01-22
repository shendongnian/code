    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class ValidInteger : ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
         {
             if (value == null)
             {
                 return ValidationResult.Success;
             }
             int i;
             
             return !int.TryParse(value.ToString(), out i) ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
         }
	}
     public class ValidIntegerValidator : DataAnnotationsModelValidator<ValidInteger>
     {
         public ValidIntegerValidator(ModelMetadata metadata, ControllerContext context, ValidInteger attribute)
             : base(metadata, context, attribute)
         {
             if(!attribute.IsValid(context.HttpContext.Request.Form[attribute.ObjectId]))
             {
                 var propertyName = metadata.PropertyName;
                 context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
                 context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);
             }
         }
     }
