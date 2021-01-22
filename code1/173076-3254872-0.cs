    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                Type t = p.GetType();
                MethodInfo mi = t.GetMethod("add", BindingFlags.NonPublic | BindingFlags.Instance);
                string result = mi.Invoke(p, new object[] {4, 5}).ToString();
                Console.WriteLine("Result = " + result);
                Console.ReadLine();
            }
    
            private int add(int x, int y)
            {
                return x + y;
            }
        }
    }
