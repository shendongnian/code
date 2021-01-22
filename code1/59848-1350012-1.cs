    public static StrongName GetStrongName(Assembly assembly)
    {
        if(assembly == null)
            throw new ArgumentNullException("assembly");
        AssemblyName assemblyName = assembly.GetName();
       
        // get the public key blob
        byte[] publicKey = assemblyName.GetPublicKey();
        if(publicKey == null || publicKey.Length == 0)
           throw new InvalidOperationException( String.Format("{0} is not strongly named", assembly));
   
        StrongNamePublicKeyBlob keyBlob = new StrongNamePublicKeyBlob(publicKey);
        // create the StrongName
        return new StrongName(keyBlob, assemblyName.Name, assemblyName.Version);
    }
    // load the assembly:
    Assembly asm = Assembly.LoadFile(path);
    StrongName sn = GetStrongName(asm);
    // at this point
    // A: assembly is loaded
    // B: assembly is signed
    // C: we're reasonably certain the assembly has not been tampered with
    // (the mechanism for this check, and it's weaknesses, are documented elsewhere)
    // all that remains is to compare the assembly's public key with 
    // a copy you've stored for this purpose, let's use the executing assembly's strong name
    StrongName mySn = GetStrongName(Assembly.GetExecutingAssembly());
    // if the sn does not match, put this loaded assembly in jail
    if (mySn.PublicKey!=sn.PublicKey)
        return false;
