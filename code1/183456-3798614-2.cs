    internal static Assembly LoadGeneratedAssembly(Type type, string defaultNamespace, out XmlSerializerImplementation contract)
    {
        ...
        AssemblyName parent = GetName(type.Assembly, true);
        partialName = Compiler.GetTempAssemblyName(parent, defaultNamespace);
        parent.Name = partialName;
        parent.CodeBase = null;
        parent.CultureInfo = CultureInfo.InvariantCulture;
        try
        {
            serializer = Assembly.Load(parent);
        }
        catch (Exception exception)
        {
          ...
        }
      ....
    }
