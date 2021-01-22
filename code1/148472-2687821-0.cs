    [AttributeUsage(AttributeTargets.Property | AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = true)]
    public class ValidateMinLengthAttribute : AbstractValidationAttribute
    {
        private IValidator validator;
        public ValidateMinLengthAttribute(int minLength)
        {
            validator = new MinLengthValidator(minLength);
        }
        public ValidateMinLengthAttribute(int minLength, string errorMessage) : base(errorMessage)
        {
            validator = new MinLengthValidator(minLength);
        }
        public override IValidator Build()
        {
            ConfigureValidatorMessage(validator);
            return validator;
        }
    }
    [Serializable()]
    public class MinLengthValidator : AbstractValidator
    {
        private int _minLength;
        private const string defaultErrorMessage = "Field must contain at least {0} characters";
        public MinLengthValidator(int minLength)
        {
            _minLength = minLength;
        }
        public override bool IsValid(object instance, object fieldValue)
        {
            if (fieldValue == null) return true;
            return fieldValue.ToString().Length >= _minLength;
        }
        public override bool SupportsBrowserValidation
        {
            get { return true; }
        }
        public override void ApplyBrowserValidation(BrowserValidationConfiguration config, InputElementType inputType, IBrowserValidationGenerator generator, System.Collections.IDictionary attributes, string target)
        {
            base.ApplyBrowserValidation(config, inputType, generator, attributes, target);
            string message = string.Format(defaultErrorMessage, _minLength);
            generator.SetMinLength(target, _minLength, ErrorMessage ?? message);
        }
        protected override string BuildErrorMessage()
        {
            return string.Format(defaultErrorMessage, _minLength);
        }
    }
