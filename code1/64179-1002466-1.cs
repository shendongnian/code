        public class RegularExpressionValidatorEx : RegularExpressionValidator
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
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.ClientScript.RegisterStartupScript(GetType(), "customVal", ClientID + @".evaluationfunction = function(val){
    var value = ValidatorGetValue(val.controltovalidate);
    if (ValidatorTrim(value).length == 0)
        return false;
    return RegularExpressionValidatorEvaluateIsValid(val);}", true);
        }
    }
