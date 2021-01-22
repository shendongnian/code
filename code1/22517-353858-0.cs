    public static string Print<T>(this IEnumerable<T> col, Func<T,string> printer)
    {
      var sb = new StringBuilder();
      foreach (T t in col)
      {
        sb.AppendLine(printer(t));
      }
      return sb.ToString();
    }
    
    string[] col = { "Foo" , "Bar" };
    string lines = col.Print( s => s);
