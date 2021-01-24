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
                var type = typeof(MethodContainer);
                var method = type.GetMethod("MyMethod");
                var mc = new MethodContainer();
                string result = (string)method.Invoke(mc, null);
                Console.WriteLine(result); //Output: This is a test
            }
        }
    
        public class MethodContainer
        {
            public string MyMethod()
            {
                return "This is a test";
            }
        }
    }
