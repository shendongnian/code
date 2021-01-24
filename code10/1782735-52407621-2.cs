    public class BaseModelValidator<T>: AbstractValidator<T> where T : BaseModel
    {
        // necessary for reusing base rules
        private readonly InternalBaseModelValidator preValidator; 
        protected BaseModelValidator()
        {
            preValidator = new InternalBaseModelValidator();
        }
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            var preValidationResult = preValidator.Validate(context.InstanceToValidate);
            if (preValidationResult.IsValid)
            {
                return true;
            }
            foreach(var error in preValidationResult.Errors)
            {
                result.Errors.Add(new ValidationFailure(error.PropertyName, error.ErrorMessage, error.AttemptedValue));
            }
            return false;
        }
    }
