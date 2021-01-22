    public class FailValidationRule : ValidationRule
    {
        public override void Validate(object sender, ValidationEventArgs e)
        {
            e.IsValid = false;
        }
    }
