    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private String displayName;
        public RequiredAttribute()
        {
            this.ErrorMessage = "{0} is required";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var attributes = validationContext.ObjectType.GetProperty(validationContext.MemberName).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (attributes != null)
                this.displayName = (attributes[0] as DisplayNameAttribute).DisplayName;
            else
                this.displayName = validationContext.DisplayName;
            return base.IsValid(value, validationContext);
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, displayName);
        } 
    }
