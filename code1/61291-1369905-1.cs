    using (var ms = new MemoryStream())
    using (var x = new XmlTextWriter(ms, new UTF8Encoding(false)) 
      { Formatting = Formatting.Indented })
    {
      // ...
      return Encoding.UTF8.GetString(ms.ToArray());
    }
