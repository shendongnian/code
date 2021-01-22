        static void Main()
        {
            Console.WriteLine(IsObject<int>()); // false
            Console.WriteLine(IsObject<object>()); // true
            Console.WriteLine(IsObject<dynamic>()); // true
            Console.WriteLine(IsObject<string>()); // false
        }
        static bool IsObject<T>()
        {
            return typeof(T) == typeof(object);
        }
