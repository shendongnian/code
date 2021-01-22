    public static class ValidationFactory
    {
        public static Result Validate<T>(T obj)
        {
            try
            {
                var validator = ObjectFactory.GetInstance<IValidator<T>>();
                return validator.Validate(obj);
            }
            catch (Exception ex)
            {
                ...
            }
        }
    }
