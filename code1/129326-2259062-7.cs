    [ConfigurationElementType(typeof(CustomValidatorData))]
    public sealed class RangeValidator : Validator
    {
        public RangeValidator(NameValueCollection attributes)
            : base(string.Empty, string.Empty) { }
    
        protected override string DefaultMessageTemplate
        {
            get { throw new NotImplementedException(); }
        }
    
        protected override void DoValidate(object objectToValidate,
            object currentTarget, string key, ValidationResults results)
        {
            Range range = (Range)currentTarget;
            if (range.Max < range.Min)
            {
                this.LogValidationResult(results,
                    "Max less than min", currentTarget, key);
            }
        }
    }
