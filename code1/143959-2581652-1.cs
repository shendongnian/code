    using System;
    class Program 
    {
        public static string MyMethod<T>()
        {
            return typeof(T).FullName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MyMethod<int>());
            Console.ReadKey();
        }
    }
