    public static void AppendCollection<T>(this StringBuilder sb, 
       List<T> col, Func<T,string> printer)
    {
      col.ForEach( o => sb.AppendLine(printer(o)));
    }
