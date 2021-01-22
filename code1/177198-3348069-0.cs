    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public abstract class ValidationAttribute : Attribute
    {
        public abstract void Validate(object value, PropertyInfo propertyInfo, ref IList<string> errors);
    }
