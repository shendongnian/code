    public static void TestGenerics(IList values) {
      foreach (object v in values) {
        if (ReferenceEquals(null,v)) {
          // v is null reference
        }
        else {
          var type = v.GetType();
          if (type.IsValueType && Equals(v, Activator.CreateInstance(type))) {
            // v is default value of its value type
          }
          else {
            // v is non-null value of some reference type
          }
        }
      }
    }
