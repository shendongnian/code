    public string GetAssemblyNamespace(Assembly asm)
    {
        string ns = @"";
        foreach (Type tp in asm.Modules.First().GetTypes()) //Iterate all types within the specified assembly.
            if (ns.Length == 0 ? true : tp.Namespace.Length < ns.Length) //Check whether that's the shortest so far.
                ns = tp.Namespace; //If it's, set it to the variable.
        return ns; //Now it is the namespace of the assembly.
    }
