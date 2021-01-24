    public class RequiredUnlessDeletingAttribute : RequiredAttribute
    {
        string DeletingProperty;
        /// <summary>
        /// Check if the object is going to be deleted skip the validation.
        /// </summary>
        /// <param name="deletingProperty">The boolean property`s name which shows the object will be deleted.</param>
        public RequiredUnlessDeletingAttribute(string deletingProperty = "MustBeDeleted") =>
            DeletingProperty = deletingProperty;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(deletingProperty);
            if ((bool)property.GetValue(validationContext.ObjectInstance))
                return ValidationResult.Success;
            return base.IsValid(value, validationContext);
        }
    }
