        static void Main()
        {
            const string qualifiedInterfaceName = "Interfaces.IMyInterface";
            var interfaceFilter = new TypeFilter(InterfaceFilter);
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles("*.dll"))
            {
                try
                {
                    var nextAssembly = Assembly.ReflectionOnlyLoadFrom(file.FullName);
                    foreach (var type in nextAssembly.GetTypes())
                    {
                        var myInterfaces = type.FindInterfaces(interfaceFilter, qualifiedInterfaceName);
                        if (myInterfaces.Length > 0)
                        {
                            // This class implements the interface
                        }
                    }
                }
                catch (BadImageFormatException)
                {
                    // Not a .net assembly  - ignore
                }                
            }
        }
        public static bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
