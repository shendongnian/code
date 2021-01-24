    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Reflection;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                MethodInfo method = typeof(Program).GetMethod("MyMethod");
                string result = (string)method.Invoke(null, null);
                Console.WriteLine(result);
    
            }
            
            public static string MyMethod()
            {
                return "LOL";
            }
        }        
    }
