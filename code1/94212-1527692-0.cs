    public void OutputProperties(object o) {
      if ( o == null ) { throw new ArgumentNullException(); }
      foreach ( var prop in o.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) ) {
        var value = prop.GetValue(o,null);
        Console.WriteLine("{0}={1}", prop.Name, value);
      }
    }
