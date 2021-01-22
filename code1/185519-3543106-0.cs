    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, 
                                             AllowMultiple = true, 
                                             Inherited = true)]
    public sealed class RequiredAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = // Error Message
        // Notice that i can include the filed name in the error message 
        // which will be provided in the FormatErrorMessage Method 
        public RequiredAttribute()
            : base(_defaultErrorMessage)
        {
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name);
        }
        public override bool IsValid(object value)
        {
            string filed = value as string;
            if (String.IsNullOrEmpty(filed))
                return false;
            else
                return true;
        }
    }
