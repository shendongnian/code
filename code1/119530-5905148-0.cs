    static TypeManager()
        {
            AppDomain.CurrentDomain.AssemblyLoad += (s, e) =>
            {
                _ScanAssembly(e.LoadedAssembly);
            };
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                _ScanAssembly(a);
            }
        }
        private static void _ScanAssembly(Assembly a)
        {
            foreach (Type t in a.GetTypes())
            {
               //optional check to filter types (by interface or attribute, etc.)
               //Add type to type map   
            }
        }
