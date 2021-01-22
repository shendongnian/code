public static string GetProductVersion()
{
  var attribute = (AssemblyVersionAttribute)Assembly
    .GetExecutingAssembly()
    .GetCustomAttributes( typeof(AssemblyVersionAttribute), true )
    .Single();
   return attribute.InformationalVersion;
}
