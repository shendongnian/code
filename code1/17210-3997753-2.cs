      foreach (var p in properties)
      {
        string name = p.Name;
        string propType = TranslateType(p.FieldType);
        if (!string.IsNullOrEmpty(propType))
          sb.AppendLine("  public {0} {1} { get; set; }".Replace("{0}", propType).Replace("{1}", name));
      }
      return classtext.Replace("{0}", className).Replace("{1}", sb.ToString());
    }
    private static string TranslateType(Type input)
    {
      string ret;
      switch (input.Name)
      {
        case "Int32": ret = "int"; break;
        case "Int64": ret = "long"; break;
        case "IntPtr": ret = "long"; break;
        case "Boolean": ret = "bool"; break;
        case "String": ret = "string"; break;
        case "Char": ret = "char"; break;
        default: ret = input.Name; break;
      }
      if (input.Name.Contains("Nullable"))
      {
        ret = "{0}?".FormatString(TranslateType(Nullable.GetUnderlyingType(input)));
      }
      return ret;
    }
