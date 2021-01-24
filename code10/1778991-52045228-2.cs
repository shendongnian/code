    using System.Reflection;
    ...
    private static Geral[] s_Derivadas = AppDomain
      .CurrentDomain
      .GetAssemblies()
      .SelectMany(asm => asm.GetTypes())
      .Where(t => typeof(Geral).IsAssignableFrom(t))
      .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
      .Select(t => Activator.CreateInstance(t) as Geral)
      .ToArray();
  
