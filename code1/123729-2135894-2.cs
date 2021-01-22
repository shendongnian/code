    public static string ToSentenceCase( string someString )
    {
      var sb = new StringBuilder( someString.Length );
      bool wasPeriodLastSeen = false;
      foreach( var c in someString )
      {
          if( wasPeriodLastSeen && !c.IsWhiteSpace ) 
          {
              sb.Append( c.ToUpper() );
              wasPeriodLastSeen = false;         
          }        
          else
          {
              if( c == '.' )  // you may want to expand this to other punctuation
                  wasPeriodLastSeen = true;
              sb.Append( c );
          }
      }
      return sb.ToString();
    }
