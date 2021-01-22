    public static string SomethingElseWithComma(this IEnumerable<string> list)
    {
      if(list == null)
          return null;
    
      return String.Join(",",list.ToArray());
    }
