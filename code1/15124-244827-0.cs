      public static IEnumerable<XElement> AsXElements(this object source)
      {
          foreach (PropertyInfo prop in source.GetType().GetProperties())
          {
              object value = prop.GetValue(source, null);
              yield return new XElement(prop.Name.Replace("_", "-"), value);
          }
      }
      public static IEnumerable<XAttribute> AsXAttributes(this object source)
      {
          foreach (PropertyInfo prop in source.GetType().GetProperties())
          {
              object value = prop.GetValue(source, null);
              yield return new XAttribute(prop.Name.Replace("_", "-"), value ?? "");
          }
      }
