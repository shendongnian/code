    static class ClassLoader
    {
        public static IEnumerable<MethodInfo> GetMethodsWithAttribute(Type attributeType, Type type)
        {
            List<MethodInfo> list = new List<MethodInfo>();
    
            foreach (MethodInfo m in type.GetMethods())
            {
                if (m.IsDefined(attributeType, false))
                {
                    list.Add(m);
                }
            }
    
            return list;
        }
    
        public static IEnumerable<Type> GetTypesWithAttribute(Type attributeType, string assemblyName)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            return GetTypesWithAttribute(attributeType, assembly);
        }
    
        public static IEnumerable<Type> GetTypesWithAttribute(Type attributeType, Assembly assembly)
        {
            List<Type> list = new List<Type>();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsDefined(attributeType, false))
                    list.Add(type);
            }
    
            return list;
        }
    }
