    public class DoNotIncludeAttribute : Attribute
    {
    }
    public static class ExtensionsOfPropertyInfo
    {
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            return propertyInfo.GetCustomAttributes(typeof(T), true).Cast<T>();
        }
        public static bool IsMarkedWith<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            return property.GetAttributes<T>().Any();
        }
    }
    public class Test
    {
        public string One { get; set; }
    
        [DoNotInclude]
        public string Two { get; set; }
    }
