    public static class StringExt
    {
      public static string Truncate( this string value, int maxLength )
      {
          return value.Length <= maxLength ? value : value.Substring(0, maxLength); 
      }
    }
    // now we can write:
    var someString = "...";
    someString = someString.Truncate( 2 );
