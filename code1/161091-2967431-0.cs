    foreach (AssemblyName asn in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
    {
    	var asm = Assembly.Load(fn);
        // I've found get types does a good job of ensuring the types are loaded.
    	asm.GetTypes();
    }
