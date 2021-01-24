    public static class MyStaticClass
    {
        private static MyClass _myClass = new MyClass();
        private static object _lockObj = new object();
        public static string GetValue(int key)
        {
            return _myClass.GetValue(key);
        }
        public static void SetValue(int key)
        {
            lock(_lockObj)
            {           
                 _myClass.SetValue(key);
            }
        }
    }
