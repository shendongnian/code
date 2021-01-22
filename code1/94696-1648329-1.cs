    bool found = false;
    string value = string.Empty;
    Type attributeType = Type.GetType(Attribute);
    AssemblyDefinition assembly = AssemblyFactory.GetAssembly(AssemblyFile);
    foreach (CustomAttribute attribute in assembly.CustomAttributes)
    {
        if (attribute.Constructor.DeclaringType.Name == attributeType.Name)
        {
            value = attribute.ConstructorParameters[0].ToString();
            found = true;
        }
    }
