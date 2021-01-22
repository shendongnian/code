    class MyRestrictedGeneric<T>
    {
        protected MyRestrictedGeneric() { }
        // Create the right class depending on type T
        public static MyRestrictedGeneric<T> Create<T>()
        {
            if (typeof(T) == typeof(string))
                return new StringImpl() as MyRestrictedGeneric<T>;
            if (typeof(T) == typeof(int))
                return new IntImpl() as MyRestrictedGeneric<T>;
            throw new InvalidOperationException("Type not supported");
        }
        // The specialized implementation are protected away
        protected class StringImpl : MyRestrictedGeneric<string> { }
        protected class IntImpl : MyRestrictedGeneric<int> { }
    }
