    void ReadList<T>(T list) where T : System.Collections.IList
    {
      foreach (Object item in list)
      {
        var props = item.GetType().GetProperties();
        foreach (var prop in props)
        {
          ReportValue(prop.Name, prop.GetValue(item, null));
        }
      }
    }
