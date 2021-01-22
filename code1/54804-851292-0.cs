    private static List<Assembly> GetListOfEntryAssemblyWithReferences()
    {
      List<Assembly> listOfAssemblies = new List<Assembly>();
      var mainAsm = Assembly.GetEntryAssembly();
      listOfAssemblies.Add(mainAsm);
    
      foreach (var refAsmName in mainAsm.GetReferencedAssemblies())
      {
        listOfAssemblies.Add(Assembly.Load(refAsmName));
      }
      return listOfAssemblies;
    }
