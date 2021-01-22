    public static class TypeExtensions
  {
    public static string GenerateClassDefinition(this Type type)
    {
      return CreateClass(type, type.Name);
    }
    private static string CreateClass(Type type, string className)
    {
      if (type.GetFields().Count() > 0) return GenerateClassFromFields(type, className);
      else return GeneratereClassFromProperties(type, className);
    }
    private static string GeneratereClassFromProperties(Type type, string className)
    {
      var properties = type.GetProperties();
      var sb = new StringBuilder();
      var classtext = @"private class {0}
