    object o = e.Row.DataItem;
    Type t = o.GetType();
    PropertyInfo pi = t.GetProperty("Foo");
    if (pi != null && pi.PropertyType == typeof(Bar))
    {
      // the property exists!
      Bar b = pi.GetValue(o, null) as Bar;
      // we have the value
      // insert your code here
      // PROFIT!  :)
    }
