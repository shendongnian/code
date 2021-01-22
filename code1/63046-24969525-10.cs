    using System;
    using System.Reflection;
    
    public static class IDExtensions
    {
        public static string ToString<T>(this ID id)
        {
            return ToString(id, typeof(T));
        }
    
        public static string ToString(this ID id, Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            {
                if ((field.FieldType == typeof(ID)) && id.Equals(field.GetValue(null)))
                {
                    return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
                }
            }
    
            foreach (var nestedType in type.GetNestedTypes())
            {
                string asNestedType = ToString(id, nestedType);
                if (asNestedType != null)
                {
                    return asNestedType;
                }
            }
    
            return null;
        }
    }
