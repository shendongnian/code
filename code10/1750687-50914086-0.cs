    using System;
    using System.Collections.Generic;
    namespace Question_Answer_Console_App
    {
        class Program
        { 
            static void Main(string[] args)
            {
                // Only a reference to a function of Enumerable return type.
                var items = GetItems<object>(); 
                // When we start the enumeration we then enter the function and initialize the first and only object for this example.
                foreach (var item in items)
                     Console.WriteLine(item);
    
                Console.Read();
            }
    
            private static IEnumerable<T> GetItems<T>()
            {
                yield return Activator.CreateInstance<T>();
            }
        }
        // Outputs: 
        // System.Object
    }
