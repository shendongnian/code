    Version version = null;
    AssemblyName[] names = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
    foreach (AssemblyName name in names)
    {
          if (name.Name == "mscorlib")
          {
                version = name.Version;
          }
    }
