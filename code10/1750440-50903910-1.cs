    public static class Extension
    {
        public static T ToNull<T>(this string value)
        {
            if (String.IsNullOrEmpty(value)) return default(T);
            Type originalType = Type.GetType(typeof(T).FullName);
            var underlyingType = Nullable.GetUnderlyingType(originalType);
            return (T)Convert.ChangeType(value, underlyingType ?? originalType);
        }
    }
