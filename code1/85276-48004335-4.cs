    public class Foo
    {
        private static Foo _Instance;
        private Foo()
        {
        }
        public static Foo GetInstance()
        {
            if (_Instance == null)
                _Instance = new Foo();
            return _Instance;
        }
        protected void Data1()
        {
        }
        public static void Data2()
        {
            GetInstance().Data1();
        }
    }
