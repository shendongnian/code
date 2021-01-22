    using System;
    
    class Test
    {
        public static T Execute<T>(Func<T> function)
        {
            return function();
        }
    
        static void Main()
        {
            Execute(delegate { return 5; });
        }
    }
