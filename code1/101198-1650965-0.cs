    public static class TypeExtensions {
      public static bool IsAnonymousType(this Type t) {
        var name = t.Name;
        if ( name.Length < 3 ) {
          return false;
        }
        return name[0] == '<' 
            && name[1] == '>' 
            && name.IndexOf("AnonymousType", StringComparison.Ordinal) > 0;
    }
