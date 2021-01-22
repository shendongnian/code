      static void PrintDisposableTypesFromFile(String path)
      {
         Assembly assembly = Assembly.LoadFrom(path);
         foreach (Type type in assembly.GetTypes())
            if (type.GetInterface("IDisposable") != null)
               Console.WriteLine(type.FullName);
      }
