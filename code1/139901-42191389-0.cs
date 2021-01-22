    using System;
    using System.Linq;
    public class Helper
    {
        public static TValue GetMethodAttributeValue<TAttribute, TValue>(Action action, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var methodInfo = action.Method;
            var attr = methodInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null ? valueSelector(attr) : default(TValue);
        }
    }
