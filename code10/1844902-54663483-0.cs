    public static class Extensions
    {
        public static bool IsNullOrDefault(this object obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return true;
            return obj.GetType().GetProperties()
                .All(x => IsNullOrEmpty(x.GetValue(obj)));
        }
        private static bool IsNullOrEmpty(object value)
        {
            if (Object.ReferenceEquals(value, null))
                return true;
            var type = value.GetType();
            return type.IsValueType
                && Object.Equals(value, Activator.CreateInstance(type));
        }
    }
