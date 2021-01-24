    //TODO: rename the method: it doesn't read property (Prop) 
    public static object GetPropValue(object src, string propName) {
      return src
        .GetType()
        .GetField(propName, BindingFlags.Public | BindingFlags.Instance)
        .GetValue(src);
    }
