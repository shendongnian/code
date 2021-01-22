    public static IEnumerable<string> GetStaticPropertyNames(Type t) {
      foreach ( var prop in t.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ) {
        yield return prop.Name; 
      }
    }
