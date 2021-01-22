    public string SpaceToComma(string input) { 
      var builder = new System.Text.StringBuilder();
      var inQuotes = false;
      foreach ( var cur in input ) {
        switch ( cur ) { 
          case ' ':
             builder.Append(inQuotes ? cur : ',');
             break;
          case '"':
             inQuotes = !inQuotes;
             builder.Append(cur);
             break;
          default:
             builder.Append(cur);
             break;
        }
      }
      return builder.ToString();
    }
