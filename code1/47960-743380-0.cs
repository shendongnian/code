    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatorAttribute : Attribute
    {
        public Type ValidatorType { get; private set; }
        public ValidatorAttribute(Type validatorType)
        {
            ValidatorType = validatorType;
        }
        public static IValidator GetValidator(object obj)
        {
            if (obj == null) return null;
            return GetValidator(obj.GetType());
        }
        public static IValidator GetValidator(Type type)
        {
            if (type == null) return null;
            ValidatorAttribute va = (ValidatorAttribute)
                Attribute.GetCustomAttribute(type, typeof(ValidatorAttribute));
            if (va == null || va.ValidatorType == null) return null;
            return (IValidator) Activator.CreateInstance(va.ValidatorType);
        }
    }
