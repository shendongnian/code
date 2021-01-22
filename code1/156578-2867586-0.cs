    public static class TypeExtensions
    {
        public static bool IsGenericTypeOf(this Type t, Type genericDefinition)
        {
            return t.IsGenericType && genericDefinition.IsGenericType && t.GetGenericTypeDefinition() == genericDefinition.GetGenericTypeDefinition();
        }
    }
