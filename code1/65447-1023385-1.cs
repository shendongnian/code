    using System;
    
    class Test
    {
        public delegate T Function<T>();
        public static T Execute<T>(Function<T> function)
        {
            return function();
        }
    
        static void Main()
        {
            Execute(delegate { return 5; });
        }
    }
