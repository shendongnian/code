    class MyRestrictedGeneric<T>
    {
        public MyRestrictedGeneric()
        {
            if (!(typeof(T) == typeof(string) || typeof(T) == typeof(int)))
                throw new InvalidOperationException("Only support string and int!");
        }
    }
