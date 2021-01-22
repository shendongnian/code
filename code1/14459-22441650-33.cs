    class Program
    {
        static void Main(string[] args)
        {
            object obj = new Alpha();
            Helper((dynamic)obj);
        }
        public static void Helper<T>(T obj)
        {
            GenericMethod<T>();
        }
        public static void GenericMethod<T>()
        {
            Console.WriteLine("GenericMethod<" + typeof(T) + ">");
        }
    }
