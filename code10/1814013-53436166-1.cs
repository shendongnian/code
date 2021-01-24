    class Program
    {
        static void Main(string[] args)
        {
            var barInstance = Foo<Bar>.GetInstance();
        }
    }
    public class Foo<T> where T : new()
    {
        protected bool knowsFu;
        private static T _instance;
        public static T GetInstance()
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
    public class Bar
    {
        public Bar()
        {
        }
    }
