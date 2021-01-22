        private bool HasGenericTypeBase(Type type, Type genericType)
        {
            while (type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType) return true;
                type = type.BaseType;
            }
            return false;
        }
