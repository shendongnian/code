      foreach (var p in properties)
      {
        string name = p.Name;
        string propType = TranslateType(p.PropertyType);
        if (!string.IsNullOrEmpty(propType))
          sb.AppendLine("  public {0} {1} { get; set; }".Replace("{0}", propType).Replace("{1}", name));
      }
      return classtext.Replace("{0}", className).Replace("{1}", sb.ToString());
    }
    private static string GenerateClassFromFields(Type type, string className)
    {
      var properties = type.GetFields();
      var sb = new StringBuilder();
      var classtext = @"private class {0}
