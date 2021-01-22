    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            ShowMethods(typeof(DateTime));
        }
        
        static void ShowMethods(Type type)
        {
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                var parameterDescriptions = string.Join
                    (", ", method.GetParameters()
                                 .Select(x => x.ParameterType + " " + x.Name)
                                 .ToArray());
                    
                Console.WriteLine("{0} {1} ({2})",
                                  method.ReturnType,
                                  method.Name,
                                  parameterDescriptions);
            }
        }
    }
