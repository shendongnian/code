    public static class TypeExtensions
    {
        public static IEnumerable<BindingDefinition> GetBindingDefinitionOf(
          this IEnumerable<Type> types, Type openGenericType)
        {
            return types.Select(type => new InterfaceTypeDefinition(type))
                .Where(d => d.ImplementsOpenGenericTypeOf(openGenericType))
                .Select(d => new BindingDefinition(d, openGenericType));
        }
        public static bool IsOpenGeneric(this Type type, Type openGenericType)
        {
            return type.IsGenericType 
                && type.GetGenericTypeDefinition().IsAssignableFrom(openGenericType);
        }
    }
