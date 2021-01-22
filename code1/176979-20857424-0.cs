    public class ValidationMethods
    {
        public static ValidationResult ValidateGreaterOrEqualToZero(decimal value, ValidationContext context)
        {
            bool isValid = true;
            if (value < decimal.Zero)
            {
                isValid = false;
            }
            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                    string.Format("The field {0} must be greater than or equal to 0.", context.MemberName),
                    new List<string>() { context.MemberName });
            }
        }
    }
