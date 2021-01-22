    using System;
    
    public class LambdaExpression
    {
       public static void Main()
       {
          Func<string, string> convert = s => s.ToUpper();
          // or simply:
          // var convert = s => s.ToUpper();
    
          string name = "RIA Guy";
          Console.WriteLine(convert(name));   
       }
    }
