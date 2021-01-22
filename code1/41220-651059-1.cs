    using System.Reflection;
    
    namespace DynamicAssembly
    {
        [AttributeUsage(AttributeTargets.Class)]
        public class ModuleAttribute : Attribute
        {
            public string Description { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var modules = from t in GetModules()
                              select t;
                foreach (var module in modules)
                {
                    ModuleAttribute[] moduleAttributes = GetModuleAttributes(module);
                    Console.WriteLine(module.FullName);
                    foreach (var moduleAttribute in moduleAttributes)
                    {
                        Console.WriteLine(moduleAttribute.Description);
                    }
                }
                Console.ReadLine();
            }
    
            public static IEnumerable<Type> GetModules()
            {
                Assembly assembly = Assembly.LoadFrom(@"C:\Temp\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
    
                return GetAssemblyClasses(assembly)
                    .Where((Type type) => { return IsAModule(type); });
            }
    
            public static IEnumerable<Type> GetAssemblyClasses(Assembly assembly)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    yield return type;
                }
            }
    
            public static bool IsAModule(Type type)
            {
                return GetModuleAttribute(type) != null;
            }
    
            public static ModuleAttribute GetModuleAttribute(Type type)
            {
                ModuleAttribute[] moduleAttributes = GetModuleAttributes(type);
                Console.WriteLine(moduleAttributes.Length);
                if (moduleAttributes != null && moduleAttributes.Length != 0)
                    return moduleAttributes[0];
                return null;
            }
    
            public static ModuleAttribute[] GetModuleAttributes(Type type)
            {
                return (ModuleAttribute[])type.GetCustomAttributes(typeof(ModuleAttribute), true);
            }
    
        }
    }
