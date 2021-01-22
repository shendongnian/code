    // calling Class1.ConditionalMethod() will be ignored at runtime 
    // unless the DEBUG constant is defined
    
    
    using System.Diagnostics;
    class Class1 
    {
       [Conditional("DEBUG")]
       public static void ConditionalMethod() {
          Console.WriteLine("Executed Class1.ConditionalMethod");
       }
    }
