    public class PopValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                ulong popVal;
                if (!ulong.TryParse((string)value, out popVal) && !(value == null))
                {
                    return new ValidationResult(false, "ValidationResult: Not a number.");
                }
                return new ValidationResult(true, null);
            }
        }
