    namespace Linq1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int value = 10;
                List<int> list = value.ToList();
            }
        }
        public static class Extensions
        {
            public static List<T> ToList<T>(this T lonely)
            {
                return new List<T>(new T[] { lonely });
            }
        }
    }
