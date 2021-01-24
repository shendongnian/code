    public static class MyStaticClass
    {
        private static readonly MyClass _myClass = new MyClass();
    
        public static string GetValue(int key)
        {
            return _myClass.GetValue(key);
        }
    }
