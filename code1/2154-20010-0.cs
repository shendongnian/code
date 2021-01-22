    public class Example
    {
        internal static class Support
        {
            private delegate bool GenericParser<T>(string s, out T o);
            private static Dictionary<Type, object> parsers =
                MakeStandardParsers();
            private static Dictionary<Type, object> MakeStandardParsers()
            {
                Dictionary<Type, object> d = new Dictionary<Type, object>();
                // You need to add an entry for every type you want to cope with.
                d[typeof(int)] = new GenericParser<int>(int.TryParse);
                d[typeof(long)] = new GenericParser<long>(long.TryParse);
                d[typeof(float)] = new GenericParser<float>(float.TryParse);
                return d;
            }
            public static bool TryParse<T>(string s, out T result)
            {
                return ((GenericParser<T>)parsers[typeof(T)])(s, out result);
            }
        }
        public class Test<T>
        {
            public static T method1(string s)
            {
                T value;
                bool success = Support.TryParse(s, out value);
                return value;
            }
        }
        public static void Main()
        {
            Console.WriteLine(Test<int>.method1("23"));
            Console.WriteLine(Test<float>.method1("23.4"));
            Console.WriteLine(Test<long>.method1("99999999999999"));
            Console.ReadLine();
        }
    }
