    public static object To(this string value, Type t) {
      object obj;
      // This is evil, I know, but is the most useful way to extend this method
      // without having an interface.
      try {
        MethodInfo method = t.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public,
          null, new Type[] { typeof(string) }, null);
        Preconditions.Check(method.ReturnType == t, "The return type doesn't match!");
        obj = method.Invoke(null, new object[]{value});
      } catch (Exception e) {
        throw new CoercionException("I can't coerce " + value + " into a " + t.Name + "!", e);
      }
      return obj;
    }
