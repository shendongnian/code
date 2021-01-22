    void ReportValue(String propName, Object propValue);
    void ReadList<T>(List<T> list)
    {
      var props = typeof(T).GetProperties();
      foreach(T item in list)
      {
        foreach(var prop in props)
        {
          ReportValue(prop.Name, prop.GetValue(item));
        }
      }
    }
