    public static class ExtensionMethods
    {
        /// <summary>
        /// Checks if a type has a generic interface. 
        /// For example 
        ///     mytype.HasGenericInterface(typeof(IList<>), typeof(int)) 
        /// will return TRUE if mytype implements IList<int>
        /// </summary>
        public static bool HasGenericInterface(this Type type, Type interf, Type typeparameter)
        {
            foreach (Type i in type.GetInterfaces())
                if (i.IsGenericType && i.GetGenericTypeDefinition() == interf)
                    if (i.GetGenericArguments()[0] == typeparameter)
                        return true;
            return false;
        }
    }
