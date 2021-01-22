    public static class AttributeExtensions
    {
        /// <summary>
        /// Get a Member Attribute from a method
        /// </summary>    
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, string MethodName, Func<TAttribute, TValue> valueSelector )where TAttribute : Attribute
        {
            var att = type.GetMethod(MethodName).GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;       
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
