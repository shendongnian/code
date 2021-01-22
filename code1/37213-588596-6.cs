    public static class Extensions
    {
        public static MethodInfo GetGenericMethod(this Type t, string name, Type[] genericArgTypes, Type[] argTypes, Type returnType)
        {
            MethodInfo foo1 = (from m in t.GetMethods(BindingFlags.Public | BindingFlags.Static)
                               where m.Name == name &&
                               m.GetGenericArguments().Length == genericArgTypes.Length &&
                               m.GetParameters().Select(pi => pi.ParameterType).SequenceEqual(argTypes) &&
                               m.ReturnType == returnType
                               select m).Single().MakeGenericMethod(genericArgTypes);
    
            return foo1;
        }
    }
