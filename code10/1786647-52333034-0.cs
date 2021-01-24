    //TODO: rename the method 
    public static object GetPropValue(object src, string propName) {
      return src
        .GetType()
        .GetField(propName, BindingFlags.Public | BindingFlags.Instance)
        .GetValue(src);
    }
