    public static Dictionary<string,object> GetStaticPropertyBag(Type t) {
      var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      var map = new Dictionary<string,object>();
      foreach ( var prop in t.GetProperties(flags) ) {
        map[prop.Name] = prop.GetValue(null,null);
      }
      return map;
    }
