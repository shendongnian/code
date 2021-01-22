        public static bool IsCollectionType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
                return true;
            }
            IEnumerable<Type> genericInterfaces = type.GetInterfaces().Where(t => t.IsGenericType);
            IEnumerable<Type> baseDefinitions = genericInterfaces.Select(t => t.GetGenericTypeDefinition());
            
            var isCollectionType = baseDefinitions.Any(t => t == typeof(ICollection<>));
            return isCollectionType;
        }
