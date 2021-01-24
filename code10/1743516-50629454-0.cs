    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);
 
     static Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            --args.Name is the assembly name passed to the GetType("FullClassName,AssemblyName");
            --Search in LoadedAssemblies by name and return it.
        }
