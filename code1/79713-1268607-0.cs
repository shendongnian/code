    using System;
    
    class Test
    {
        static void Main()
        {
            object first = 2;
            object second = 2;
            
            // Compares reference equality: false
            Console.WriteLine(first == second);
            
            // Compares value equality: true
            Console.WriteLine(object.Equals(first, second));
        }
    }
