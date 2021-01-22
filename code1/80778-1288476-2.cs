    List<Assembly> allAssemblies = new List<Assembly>();
    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        
    foreach (string dll in Directory.GetFiles(path, "*.dll"))
    	allAssemblies.Add(Assembly.LoadFile(dll));
