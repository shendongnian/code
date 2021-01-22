    using System.Reflection;
    static Program()
    {
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
        {
            AssemblyName requestedName = new AssemblyName(e.Name);
    
            if (requestedName.Name == "AssemblyNameToRedirect")
            {
                // Put code here to load whatever version of the assembly you actually have
    
                return Assembly.LoadFrom("RedirectedAssembly.DLL");
            }
            else
            {
                return null;
            }
        };
    }
