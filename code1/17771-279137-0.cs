      foreach (AssemblyName name in Assembly.GetEntryAssembly().GetReferencedAssemblies()) {
        Assembly asm = Assembly.Load(name);
        foreach (Type t in asm.GetTypes()) {
          if (t.IsAbstract) continue;
          foreach (MethodInfo mi in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)) {
            int dot = mi.Name.LastIndexOf('.');
            string s = mi.Name.Substring(dot + 1);
            if (!s.StartsWith("get_") && !s.StartsWith("set_")) continue;
            if (mi.IsFinal)
              Console.WriteLine(mi.Name);
          }
        }
      }
