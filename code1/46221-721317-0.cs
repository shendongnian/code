    public static string ReplaceSingle(this string source, char toReplace, char newChar) {
      var index = source.IndexOf(toReplace);
      if ( index < 0 ) {
        return source;
      }
      var builder = new StringBuilder();
      for( var i = 0; i < source.Length; i++ ) {
        if ( i == index ) {
          builder.Append(newChar);
        } else {
          builder.Append(source[i]);
        }
      }
      return builder.ToString();
    }
