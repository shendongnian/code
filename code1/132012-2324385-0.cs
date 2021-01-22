    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
    foreach (var assemblyName in assembly.GetReferencedAssemblies()) {
      try {
        Assembly.ReflectionOnlyLoad(assemblyName.FullName);
      } catch {
        Assembly.ReflectionOnlyLoadFrom(Path.Combine(Path.GetDirectoryName(assemblyPath), assemblyName.Name + ".dll"));
      }
    }
