    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class RangeIfTrueAttribute : RangeAttribute
    {
        private readonly string _NameOfBoolProp;
        public RangeIfTrueAttribute(string nameOfBoolProp, int min, int max) : base(min, max)
        {
            _NameOfBoolProp = nameOfBoolProp;
        }
        public RangeIfTrueAttribute(string nameOfBoolProp, double min, double max) : base(min, max)
        {
            _NameOfBoolProp = nameOfBoolProp;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_NameOfBoolProp);
            if (property == null)
                return new ValidationResult($"{_NameOfBoolProp} not found");
            var boolVal = property.GetValue(validationContext.ObjectInstance, null);
            if (boolVal == null || boolVal.GetType() != typeof(bool))
                return new ValidationResult($"{_NameOfBoolProp} not boolean");
            if ((bool)boolVal)
            {
                return base.IsValid(value, validationContext);
            }
            return null;
        }
    }
