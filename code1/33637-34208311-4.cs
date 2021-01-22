    namespace Test
    {
        public class FancyClass<T>
        {
            ///
            public string FancyMethod<K>(T value) { return "something fancy"; }
        }
        public class Test
        {
            public static void Main(string[] args) { }
        }
    }
