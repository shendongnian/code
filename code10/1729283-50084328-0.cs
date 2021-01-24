    using System;
    
    class Program
    {
        static void Main()
        {
            Array outputs = Array.CreateInstance(
                typeof(object), // Element type
                new[] { 5 },    // Lengths                                             
                new[] { 1 });   // Lower bounds
            
            for (int i = 1; i <= 5; i++)
            {
                outputs.SetValue($"Value {i}", i);
            }
            Console.WriteLine("Set indexes 1-5 successfully");
            // This will throw an exception
            outputs.SetValue("Bang", 0);        
        }
    }
