    using System;
    
    class Test
    {
        static void Main()
        {
            foreach (var prop in typeof(Foo).GetProperties())
            {
                Console.WriteLine(prop.Name);
            }
        }
    }
