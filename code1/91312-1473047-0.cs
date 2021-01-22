    public static class StringExtensions
    {
      public static string ToProperCase( this string original )
      {
        if( original.IsNullOrEmpty() )
          return original;
    
        string result = _properNameRx.Replace( original.ToLower( CultureInfo.CurrentCulture ), HandleWord );
        return result;
      }
    
      public static string WordToProperCase( this string word )
      {
        if( word.IsNullOrEmpty() )
          return word;
    
        if( word.Length > 1 )
          return Char.ToUpper( word[0], CultureInfo.CurrentCulture ) + word.Substring( 1 );
    
        return word.ToUpper( CultureInfo.CurrentCulture );
      }
    
      private static readonly Regex _properNameRx = new Regex( @"\b(\w+)\b" );
    
      private static readonly string[] _prefixes = { "mc" };
    
      private static string HandleWord( Match m )
      {
        string word = m.Groups[1].Value;
    
        foreach( string prefix in _prefixes )
        {
          if( word.StartsWith( prefix, StringComparison.CurrentCultureIgnoreCase ) )
            return prefix.WordToProperCase() + word.Substring( prefix.Length ).WordToProperCase();
        }
    
        return word.WordToProperCase();
      }
    }
