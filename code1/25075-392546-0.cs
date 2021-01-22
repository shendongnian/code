    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace Forum
    {
        class Program
        {
            static void Main(string[] args)
            {
                // get your assemblies and types you can register
                Assembly a = Assembly.GetExecutingAssembly();
                var types = a.GetTypes();            
                var bindTo = from t in types
                             where t.IsAbstract || t.IsInterface
                             select t;
    
                // apply your conventions to filter our types to be registered
                var interfacePairs = from t in bindTo.Where(x => x.IsInterface)
                                     let match = types.FirstOrDefault(x => x.Name ==     t.Name.Substring(1))
                                     where match != null
                                     select new Pair { To = t, From = match };
                var abstractPairs = new Pair[] {};
                // setup the generic form of the method to register the types
                var thisType = typeof(Program);
                var bindings = BindingFlags.Static | BindingFlags.Public;
                MethodInfo genericMethod = thisType.GetMethod("RegisterType", bindings);            
                // register all your types by executing the 
                // specialized generic form of the method
                foreach (var t in interfacePairs.Concat(abstractPairs))
                {
                    Type[] genericArguments = new Type[] { t.To, t.From };
                    MethodInfo method = genericMethod.MakeGenericMethod(genericArguments);
                    method.Invoke(null, new object [] {});
                }
                Console.ReadKey();
            }
    
            public static void RegisterType<To, From>()
            {
                Console.WriteLine("Register { To: {0} From: {1} }", typeof(To), typeof(From));
            }
            // Test classes that should be picked up
            interface ITest { }
            class Test : ITest { }
    
            class Pair
            {
                public Type To { get; set; }
                public Type From { get; set; }
            }        
        }
    }
