    using System;
    using System.Reflection;
    
    public class Test
    {
        public static void Refer(ref int a,ref int b)
        {
        }
        
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("Refer");
            ParameterInfo[] parameters = method.GetParameters();
            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine("{0} is ref? {1}",
                                  parameter.Name,
                                  parameter.ParameterType.IsByRef);
            }
        }
    }
