    public static class Extensions
    {
        public static IDictionary<string, object> GetSimpleFieldValues(this object obj)
        {
            return obj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(f => f.FieldType.IsSimpleType())
                .ToDictionary(k => k.Name, v => v.GetValue(obj));
        }
    
        public static bool IsSimpleType(this Type type)
        {
            return type.IsValueType 
                || type.IsPrimitive 
                || new Type[] {
                        typeof(String),
                        typeof(Decimal),
                        typeof(DateTime),
                        typeof(DateTimeOffset),
                        typeof(TimeSpan),
                        typeof(Guid)
                    }.Contains(type) 
                || Convert.GetTypeCode(type) != TypeCode.Object;
        }
    }
