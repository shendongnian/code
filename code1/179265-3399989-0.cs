    public static class SharedObjects
    {
        private static MyClass obj = new MyClass();
        public static MyClass GetObj() 
        {
            return obj;
        }
    }
