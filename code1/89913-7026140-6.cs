    /// <summary>
    /// Prints the graph of this object using Debug.Print.
    /// </summary>
    /// <param name="o">This object.</param>
    /// <param name="prefix">Optional text to prepend to all lines printed by this method.
    /// </param>
    public static void PrintGraph(this object o, string prefix = "")
    {
       Type t = o.GetType(); if (prefix != "") prefix = "     " + prefix;
       foreach (PropertyInfo p in t.GetProperties())
          if (p.PropertyType.IsConvertible()) Debug.Print(prefix + p.Name + ": " +
             Convert.ToString(p.GetValue(o, null)));
          else if (p.PropertyType.IsEnumerable())
             foreach (object sub in (IEnumerable)p.GetValue(o, null)) 
                PrintGraph(sub, prefix + p.Name + ": ");
          else if (p.SimpleGetter()) 
             PrintGraph(p.GetValue(o, null), prefix + p.Name + ": ");
       if (t.IsEnumerable()) foreach (object sub in (IEnumerable)o) PrintGraph(o);
    }
