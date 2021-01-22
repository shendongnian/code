    static class Converter<T>
    {
        public static string Convert(T data)
        {
            return Convert((dynamic)data);
        }
    
        private static string Convert(Int16 data) => $"Int16 {data}";
        private static string Convert(UInt16 data) => $"UInt16 {data}";
        private static string Convert(Int32 data) => $"Int32 {data}";
        private static string Convert(UInt32 data) => $"UInt32 {data}";
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Converter<Int16>.Convert(-1));
            Console.WriteLine(Converter<UInt16>.Convert(1));
            Console.WriteLine(Converter<Int32>.Convert(-1));
            Console.WriteLine(Converter<UInt32>.Convert(1));
        }
    }
