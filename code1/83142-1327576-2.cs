    public static Boolean AreEqual<T>(T a, T b) {
      foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        if (Object.Equals(propertyInfo.GetValue(a, null),
                          propertyInfo.GetValue(b, null)))
          return true;
      return false;
    }
