    using System;
        static class Generic
        {
            public static string WhatIsT<T>(T value)
            {
                return $"T is {value.GetType().FullName}";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int i = 5;
                Console.WriteLine(Generic.WhatIsT(i));
                string s = "hello";
                Console.WriteLine(Generic.WhatIsT(s));
                s = null;
                Console.WriteLine(Generic.WhatIsT(s));
                Console.ReadLine();
            }
        }
