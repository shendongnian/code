    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //You can do whatever you want here
            double check;
            if (!double.TryParse(value.ToString(),out check))
            {
                //ValidationResult(false,*) => in error
                return new ValidationResult(false, "Please enter a number");
            }
            //ValidationResult(true,*) => is ok
            return new ValidationResult(true, null);
        }
    }
