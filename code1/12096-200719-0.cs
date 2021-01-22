    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Class1
        {
            public static void sayHelloTo(
                [Optional,
                DefaultParameterValue("world")] string whom)
            {
                Console.WriteLine("Hello " + whom);
            }
    
            [STAThread]
            static void Main(string[] args)
            {
                MethodInfo mi = typeof(Class1).GetMethod("sayHelloTo");
                mi.Invoke(null, new Object[] { Missing.Value });
            }
        }
    }
