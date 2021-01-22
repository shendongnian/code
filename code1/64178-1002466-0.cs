      public class ReqularExpressionValidatorEx : RegularExpressionValidator
    {
        protected override bool EvaluateIsValid()
        {
            string controlValidationValue = base.GetControlValidationValue(base.ControlToValidate);
            if ((controlValidationValue == null) || (controlValidationValue.Trim().Length == 0))
            {
                return false;
            }
            return base.EvaluateIsValid();
        }
    }
