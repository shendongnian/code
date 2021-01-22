    static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
         string partialName = args.Name.Substring(0, args.Name.IndexOf(','));
         return Assembly.Load(new AssemblyName(partialName));
    }
