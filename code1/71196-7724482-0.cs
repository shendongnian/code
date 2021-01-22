        public static bool Implements<I>(this Type type) where I : class
        {
             if (!typeof(I).IsInterface)
             {
                 throw new ArgumentException("Only interfaces can be 'implemented'.");
             }
             return typeof(I).IsAssignableFrom(type);
        }
