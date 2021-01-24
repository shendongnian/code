    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            // Display the contents of any method.
            Action<string> prntAct = TestMethod;
            PrintDelegate(prntAct);
            Action<string, string> prntAct2 = TestMethod2;
            PrintDelegate(prntAct2);
            Console.ReadKey();
        }
        public static void TestMethod(string xyz)
        {
            Console.WriteLine("Some random work to do.");
        }
        public static void TestMethod2(string abc, string def)
        {
            Console.WriteLine("Some other random work to do.");
        }
        private static void PrintDelegate(Delegate del)
        {
            var values = new List<object>();
            foreach (var param in del.Method.GetParameters())
            {
                Console.WriteLine($"{param.Name} : {param.ParameterType}");
                if (param.ParameterType == typeof(string))
                {
                    values.Add(param.Name);
                }
                else
                {
                    values.Add(null);
                }
            }
        }
    }
