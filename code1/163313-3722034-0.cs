    private static IEnumerable<string> GetBinFolders()
    {
      //TODO: The AppDomain.CurrentDomain.BaseDirectory usage is not correct in 
      //some cases. Need to consider PrivateBinPath too
      List<string> toReturn = new List<string>();
      //slightly dirty - needs reference to System.Web.  Could always do it really
      //nasty instead and bind the property by reflection!
      if (HttpContext.Current != null)
      {
        toReturn.Add(HttpRuntime.BinDirectory);
      }
      else
      {
        //TODO: as before, this is where the PBP would be handled.
        toReturn.Add(AppDomain.CurrentDomain.BaseDirectory);
      }
      return toReturn;
    }
    private static void PreLoadDeployedAssemblies()
    {
      foreach(var path in GetBinFolders())
      {
        PreLoadAssembliesFromPath(path);
      }
    }
    private static void PreLoadAssembliesFromPath(string p)
    {
      //S.O. NOTE: ELIDED - ALL EXCEPTION HANDLING FOR BREVITY
      //get all .dll files from the specified path and load the lot
      FileInfo[] files = null;
      //you might not want recursion - handy for localised assemblies 
      //though especially.
      files = new DirectoryInfo(p).GetFiles("*.dll", 
          SearchOption.AllDirectories);
      
      AssemblyName a = null;
      string s = null;
      foreach (var fi in files)
      {
        s = fi.FullName;
        //now get the name of the assembly you've found, without loading it
        //though (assuming .Net 2+ of course).
        a = AssemblyName.GetAssemblyName(s);
        //sanity check - make sure we don't already have an assembly loaded
        //that, if this assembly name was passed to the loaded, would actually
        //be resolved as that assembly.  Might be unnecessary - but makes me
        //happy :)
        if (!AppDomain.CurrentDomain.GetAssemblies().Any(assembly => 
          AssemblyName.ReferenceMatchesDefinition(a, assembly.GetName())))
        {
          //crucial - USE THE ASSEMBLY NAME.
          //in a web app, this assembly will automatically be bound from the 
          //Asp.Net Temporary folder from where the site actually runs.
          Assembly.Load(a);
        }
      }
    }
