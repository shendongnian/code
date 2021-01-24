    using System;
    
    public class Program 
    {
        public static void Main(string[] args)
        {
            // Determine which type to initialize first based on whether there
            // are any command line arguemnts.
            if (args.Length > 0)
            {
                Class2.DoNothing();
            }
            Console.WriteLine($"Class1.Value1: {Class1.Value1}"); 
            Console.WriteLine($"Class2.Value2: {Class2.Value2}"); 
        }
    }
    
    public class Class1
    {
        public static readonly string Value1 =
            $"When initializing Class1.Value1, Class2.Value2={Class2.Value2}";
        
        static Class1() {}
    }
    
    public class Class2
    {
        public static readonly string Value2 =
            $"When initializing Class2.Value2, Class2.Value2={Class1.Value1}";
    
        static Class2() {}
        
        public static void DoNothing() {}
    }
