    public static class AttributeSelection
    {
        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            if(provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            return provider.GetCustomAttributes(typeof(T), inherit).Cast<T>();
        }
    }
