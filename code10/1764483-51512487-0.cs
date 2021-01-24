    AssemblyDefinition assbDef = AssemblyDefinition.ReadAssembly("x.dll");
    TypeDefinition type = assbDef.MainModule.GetType("NameSpace.MyClass").Resolve();
    foreach (CustomAttribute attr in type.CustomAttributes)
    {
        TypeReference argTypeRef = null;
        int? index = null;
        for (int i = 0; i < attr.ConstructorArguments.Count; i++)
        {
            CustomAttributeArgument arg = attr.ConstructorArguments[i];
            string stringValue = arg.Value as string;
            if (stringValue == "Name")
            {
                argTypeRef = arg.Type;
                index = i;
            }
        }
        if (index != null)
        {
            attr.ConstructorArguments[(int)index] = new CustomAttributeArgument(argTypeRef, newName);
        }
    }    
    assbDef.Write("y.dll");
