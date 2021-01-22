    class Example
    {
        private static object field1 = new object();
        public static void SomeMethod()
        {
            object variable1 = new object();
            // ...
        }
        public static void Deref()
        {
            field1 = null;
        }
    }
