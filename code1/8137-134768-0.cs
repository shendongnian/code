    using System;
    using Host;
    
    namespace Client
    {
        public class MyClass : IMyInterface
        {
            public int _id;
            public string _name;
    
            public MyClass(int id,
                string name)
            {
                _id = id;
                _name = name;
            }
    
            public string GetOutput()
            {
                return String.Format("{0} - {1}", _id, _name);
            }
        }
    }
    
    
    namespace Host
    {
        public interface IMyInterface
        {
            string GetOutput();
        }
    }
    
    
    using System;
    using System.Reflection;
    
    namespace Host
    {
        internal class Program
        {
            private static void Main()
            {
                //These two would be read in some configuration
                const string dllName = "Client.dll";
                const string className = "Client.MyClass";
    
                try
                {
                    Assembly pluginAssembly = Assembly.LoadFrom(dllName);
                    Type classType = pluginAssembly.GetType(className);
    
                    var plugin = (IMyInterface) Activator.CreateInstance(classType,
                                                                         42, "Adams");
    
                    if (plugin == null)
                        throw new ApplicationException("Plugin not correctly configured");
    
                    Console.WriteLine(plugin.GetOutput());
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.ToString());
                }
            }
        }
    }
