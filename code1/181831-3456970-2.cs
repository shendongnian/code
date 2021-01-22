    public static class ObjectExtensions
    {
        /// <summary>
        /// Cast Object to anonymous type.
        /// E.G.: new Object().ToAnonymousType(new { Property = new Type() });
        /// </summary>
        public static T ToAnonymousType<T>(this Object o, T t)
        {
            return (T)o;
        }
    }
