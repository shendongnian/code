    public static string GetTypeName(Type t) {
      if (!t.IsGenericType) return t.Name;
      string txt = t.Name.Substring(0, t.Name.IndexOf('`')) + "<";
      int cnt = 0;
      foreach (Type arg in t.GetGenericArguments()) {
        if (cnt > 0) txt += ", ";
        txt += GetTypeName(arg);
        cnt++;
      }
      return txt + ">";
    }
