    using System.Reflection;
    ...
    private static Geral[] s_Derivadas = AppDomain
      .CurrentDomain
      .GetAssemblies()                                       // scan assemblies 
      .SelectMany(asm => asm.GetTypes())                     // types within them
      .Where(t => !t.IsAbstract)                             // type is not abstract
      .Where(t => typeof(Geral).IsAssignableFrom(t))         // type derived from Geral
      .Where(t => t.GetConstructor(Type.EmptyTypes) != null) // has default constructor
      .Select(t => Activator.CreateInstance(t) as Geral)     // create type's instance
      .ToArray();                                            // materialized as array
  
