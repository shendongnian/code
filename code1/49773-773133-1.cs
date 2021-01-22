    using System;
    
    class Test
    {
        static void Main()
        {
            Type func = typeof(Func<,,,,>);
            Type generic = func.MakeGenericType
                (typeof(int), typeof(int), typeof(string),
                 typeof(int), typeof(int));
            Console.WriteLine(generic);
        }
    }
