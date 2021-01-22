    var assembliesToLoad = { "MY_SLN.PROJECT_1", "MY_SLN.PROJECT_2" };
        
    // First trying to get all in above list, however this might not 
    // load all of them, because CLR will exclude the ones 
    // which are not used in the code
    List<Assembly> dataAssembliesNames =
       AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => AssembliesToLoad.Any(a => assembly.GetName().Name == a))
                .ToList();
            
    var loadedPaths = dataAssembliesNames.Select(a => a.Location).ToArray();
            
    var compareConfig = StringComparison.InvariantCultureIgnoreCase;
    var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
        .Where(f =>
        {
           // filtering the ones which are in above list
           var lastIndexOf = f.LastIndexOf("\\", compareConfig);
           var dllIndex = f.LastIndexOf(".dll", compareConfig);
            
           if (-1 == lastIndexOf || -1 == dllIndex)
           {
              return false;
           }
            
           return AssembliesToLoad.Any(aName => aName == 
              f.Substring(lastIndexOf + 1, dllIndex - lastIndexOf - 1));
         });
            
    var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
    toLoad.ForEach(path => dataAssembliesNames.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
            
    if (dataAssembliesNames.Count() != AssembliesToLoad.Length)
    {
       throw new Exception("Not all assemblies were loaded into the  project!");
    }
