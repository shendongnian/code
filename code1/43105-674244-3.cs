    <%# GetAsCsv(((ArrayFields)Container.DataItem).Fields) %>
    public string GetAsCsv(IEnumerable<Fields> fields)
    {
      var builder = new StringBuilder();
      foreach(var f in fields)
      {
        builder.Append(f);
        builder.Append(",");
      }
      builder.Remove(builder.Length - 1);
      return builder.ToString();
    }
