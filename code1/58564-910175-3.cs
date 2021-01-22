    static class Convert
    {
      public static Int32? ConvertNullable(this string s)
      {
        int value; 
        bool valid = int.TryParse(out value); 
        return valid ? new int?( value) : null;
      }
    }
    ds.Split(',')
      .Select( s => Convert.ConvertNullable(s))
      .Where(r=>r != null)
      .Select(r=>r.Value)
      .ToList();
