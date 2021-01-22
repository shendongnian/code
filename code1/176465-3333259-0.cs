    public string this[string field]
    {
      get
      {
        PropertyInfo prop = GetType().GetProperty(field);
        prop.GetValue(this, null);
      }
      set
      {
        PropertyInfo prop = GetType().GetProperty(field);
        prop.SetValue(this, value, null);
      }
    }
