    public class StringNotZeroRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (textBox1.Text.Length == 0)
                return new ValidationResult(true, null);
    
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                // number is 0?
                if (result == 0)
                {
                    return new ValidationResult(false, "0 is not allowed");
                }
            }
            else
            {
                // not a number at all
                return new ValidationResult(false, "not a number");
            }
            
            return new ValidationResult(true, null);
        }
    }
