    public static class TypeExtensions
    {
        public static PropertyInfo[] GetFilteredProperties(this Type type)
        {
            return type.GetProperties().Where(pi => !Attribute.IsDefined(pi, typeof(SkipPropertyAttribute))).ToArray();
        }
    }
