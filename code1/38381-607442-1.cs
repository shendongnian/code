    object o = e.Row.DataItem;
    Type t = o.GetType();
    PropertyInfo pi = t.GetProperty("StringProperty");
    if (pi != null && pi.PropertyType == typeof(string))
    {
      // the property exists!
      string s = pi.GetValue(o, null) as string;
      // we have the value
      // insert your code here
      // PROFIT!  :)
    }
