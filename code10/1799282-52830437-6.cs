    public void MyMethod(object obj)
    {
       if (!obj.IsAnonymousType())
       {
          throw new ArgumentException($"Object of this type is not supported!");
       }
       MyMethod(obj.ToDictionary<int>());
    }
    public void MyMethod(IDictionary<string, int> dict)
    {
        // your code here...
    }
    ...
    public static class ObjHelper
    {
        public static IDictionary<string, T> ToDictionary<T>(this object obj)
        {
            var objType = obj.GetType();
            // This call is optimized by compiler
            var props = objType.GetProperties();
            if (typeof(T) == typeof(object))
            {
                // we don't need to check if property is of certain type
                return props?.ToDictionary(p => p.Name, p => (T)p.GetValue(obj)) ?? new Dictionary<string, T>();
            }
            // It will ignore all types except of T
            return props?.Where(p => p.PropertyType == typeof(T)).ToDictionary(p => p.Name, p => (T)p.GetValue(obj)) ?? new Dictionary<string, T>();
        }
        public static bool IsAnonymousType(this object obj)
        {
            var type = obj.GetType();
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }
    }
