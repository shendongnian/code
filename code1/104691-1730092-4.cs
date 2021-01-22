    public static class SomeFactory
    {
        public static T CreateSomeObject<T>()
        {
            T result = Activator.CreateInstance<T>();
            // perform any extra initialization
            return result;
        }
    }
