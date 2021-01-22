    public class ValidIntegerValidator : DataAnnotationsModelValidator<ValidInteger>
     {
         public ValidIntegerValidator(ModelMetadata metadata, ControllerContext context, ValidInteger attribute)
             : base(metadata, context, attribute)
         {
             var propertyName = metadata.PropertyName;
             context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
             context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);
         }
     }
