    using System;
    using System.Reflection;
    
    public class ShowTypeCounts
    {
        static void Main()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            foreach (Assembly assembly in domain.GetAssemblies())
            {
                Console.WriteLine("{0}: {1}",
                                  assembly.GetName().Name,
                                  assembly.GetExportedTypes().Length);
            }
        }
    }
