    using System;
    using System.Reflection;
    
    namespace SO2744885
    {
        class Program
        {
            public void DoSomething(string parameterA, int parameterB)
            {
                Console.Out.WriteLine(parameterA + ": " + parameterB);
            }
    
            static void Main(string[] args)
            {
                var parameters = new object[] { "someValue", 5 };
                Program p = new Program();
                MethodInfo mi = typeof(Program).GetMethod("DoSomething");
                mi.Invoke(p, parameters);
            }
        }
    }
