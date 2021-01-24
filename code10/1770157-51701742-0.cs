         public class StringError : StringLengthAttribute
         {
        private ErrorProvider _error;
        private string _key;
        public StringError(int maxlength, string key):base(maxlength)
        {
            _key = key;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _error = (ErrorProvider)validationContext.GetService(typeof(ErrorProvider));
            return base.IsValid(value, validationContext);
        }
        public override string FormatErrorMessage(string name)
        {
            if (_error != null)
            {
                return _error.Error(_key);
            }
            return base.FormatErrorMessage(name);   
        }
        }
