    public enum AssemblyType 
    { 
        CompactFramework, 
        Silverlight,
        FullFramework, 
        NativeBinary 
    } 
     
    public AssemblyType GetAssemblyType(string pathToAssembly) 
    { 
        try 
        { 
            Assembly asm = Assembly.LoadFrom(pathToAssembly); 
            var mscorlib = asm.GetReferencedAssemblies().FirstOrDefault(a => string.Compare(a.Name, "mscorlib", true) == 0); 
            ulong token = BitConverter.ToUInt64(mscorlib.GetPublicKeyToken(), 0); 
     
            switch (token) 
            { 
                case 0xac22333d05b89d96: 
                    return AssemblyType.CompactFramework; 
                case 0x89e03419565c7ab7: 
                    return AssemblyType.FullFramework; 
                case 0x8e79a7bed785ec7c:
                    return AssemblyType.Silverlight;
                default: 
                    throw new NotSupportedException(); 
            } 
        } 
        catch (BadImageFormatException) 
        { 
            return AssemblyType.NativeBinary; 
        } 
    }
