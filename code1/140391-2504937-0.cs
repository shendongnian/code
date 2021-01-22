    public static IEnumerable<string> GetDifferingProperties
        (object source, object target) {
      // Terminate recursion - equal objects don't have any differing properties
      if (source == target) return new List<string>();
      // Compare properties of two objects that are not equal
      var sourceProperties = source.GetType().GetProperties();
      var targetProperties = target.GetType().GetProperties();
      return
        from s in sourceProperties
        from t in targetProperties
        where s.Name == t.Name && s.PropertyType == t.PropertyType 
        let sVal = s.GetValue(source, null)
        let tVal = t.GetValue(target, null)
        // Instead of comparing the objects directly using '==', we run
        // the method recursively. If the two objects are equal, it returns
        // empty list immediately, otherwise it generates multiple properties
        from name in GetDifferingProperties(sVal, tVal)
        select name;
    }
