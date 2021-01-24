    using System;
    using System.Linq;
    using System.Reflection;
    
    #if DEBUG
    [assembly:AssemblyConfiguration("debug")]
    #else
    [assembly:AssemblyConfiguration("release")]
    #endif
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main()
            {
                // this should be the filename of your DLL
                var filename = typeof(Program).Assembly.Location;
    
                var assembly = Assembly.LoadFile(filename);
                var data = assembly.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(AssemblyConfigurationAttribute));
                if (data != null)
                {
                    // this will be the argument to AssemblyConfigurationAttribute
                    var arg = data.ConstructorArguments.First().Value.ToString();
                    Console.WriteLine(arg);
                }
            }
        }   
    }
