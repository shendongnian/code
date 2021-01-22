    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace Interfaces
    {
        interface IFoo {}
        interface IBar {}
        interface IBaz {}
    }
    
    public class Test
    {
        public static void CallMe<T>()
        {
            Console.WriteLine("typeof(T): {0}", typeof(T));
        }
    
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("CallMe");
            
            var types = typeof(Test).Assembly.GetTypes()
                                    .Where(t => t.Namespace == "Interfaces");
            
            foreach (Type type in types)
            {
                MethodInfo genericMethod = method.MakeGenericMethod(new Type[] {type});
                genericMethod.Invoke(null, null); // No target, no arguments
            }
        }
    }
