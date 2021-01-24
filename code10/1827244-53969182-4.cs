    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public static class UnmanagedTypeExtensions
    {
        private static Dictionary<Type, bool> cachedTypes =
        new Dictionary<Type, bool>();
        public static bool IsUnManaged(this Type t)
        {
            var result = false;
            if (cachedTypes.ContainsKey(t))
                return cachedTypes[t];
            else if (t.IsGenericType || !t.IsValueType || Nullable.GetUnderlyingType(t) != null)
                result = false;
            else if (t.IsPrimitive || t.IsPointer || t.IsEnum)
                result = true;
            else
                result = t.GetFields(BindingFlags.Public | 
                   BindingFlags.NonPublic | BindingFlags.Instance)
                    .All(x => x.FieldType.IsUnManaged());
            cachedTypes.Add(t, result);
            return result;
        }
    }
