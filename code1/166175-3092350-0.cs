    class StringList : List<string> {
       public override string ToString() {
          string result = string.Empty;
          foreach( string item in this ) {
             if( result.Length != 0 ) {
                result += ",";
             }
             result += item;
          }
          return result;
       }
    }
