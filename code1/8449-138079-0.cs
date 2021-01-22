    public static class ReflectionExt
    {
        public static object GetAttr(this object obj, string name)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Instance | 
                                     BindingFlags.Public | 
                                     BindingFlags.GetProperty;
        
            return type.InvokeMember(name, flags, Type.DefaultBinder, obj, null);
        }
    }
