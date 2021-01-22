        public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            return type
                .GetTypeInfo()
                .ImplementedInterfaces
                .Any(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == interfaceType);
        }
