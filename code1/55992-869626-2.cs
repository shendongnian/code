    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            Foo(null);
            Bar(null);
        }
        
        static void Foo(object resource)
        {
            PrintParameters(MethodBase.GetCurrentMethod());
        }
        
        static void Bar(object other)
        {
            PrintParameters(MethodBase.GetCurrentMethod());
        }
        
        static void PrintParameters(MethodBase method)
        {
            Console.WriteLine("{0}:", method.Name);
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                Console.WriteLine(" {0} {1}",
                                  parameter.ParameterType,
                                  parameter.Name);
            }
        }
    }
