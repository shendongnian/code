    static class PropertyGetter<X>
    {
      private static readonly Dictionary<string, Converter<X, object>> cached;
      public Converter<X, object> this[string propertyName]
      {
        get {
          Converter<X, object> result;
          lock (this) if (!cached.TryGetValue(propertyName, out result)) {
            PropertyInfo pi = typeof(X).GetProperty(propertyName, true);
            if (pi == null) throw new ArgumentException("Type " + typeof(X).Name + " has no property named " + propertyName, propertyName);
             MethodInfo getter = pi.GetGetMethod();
             if (getter == null) throw new ArgumentException("Type " + typeof(X).Name + " has a property named " + propertyName + " but it is not readable", propertyName);
             result = (Converter<X, object>)Delegate.CreateDelegate(typeof (Converter<X, object>), getter);
             cached.Add(propertyName, result);
           }
           return result;
         }
      }
    }
    List<Tuple<X, Y>> FindCommonEntries<X, Y>(IEnumerable<X> listA, IEnumerable<Y> listB, string propertyNameA, string propertyNameB, out List<X> onlyA, out List<Y> onlyB)
    {
        return FindCommonEntries<X,Y>(listA, listB, PropertyGetter<X>[propertyName], PropertyGetter<Y>[propertyName], out onlyA, out onlyB);
    }
    List<Tuple<X, Y>> FindCommonEntries<X, Y>(IEnumerable<X> listA, IEnumerable<Y> listB, Converter<X, object> getA, Converter<Y, object> getB, out List<X> onlyA, out List<Y> onlyB)
    {
        Dictionary<object, Tuple<List<X>, bool>> mapA = new Dictionary<object, X>();
        foreach (X x in listA) {
          Tuple<List<X>,bool> set;
          object key = getA(x);
          if (!mapA.TryGetValue(key, out set))
            mapA.Add(key, set = new Tuple<List<X>, bool>(new List<X>(), false));
          set.first.Add(x);
        }
        onlyB = new List<Y>();
        List<Tuple<X, Y>> common = new List<Tuple<X, Y>>();
        foreach (Y y in listB) {
          Tuple<List<X>,bool> match;
          if (mapA.TryGetValue(getB(y), out match)) {
            foreach (X x in match.first) common.Add(x, y);
            match.second = true;
          }
          else
            onlyB.Add(y);
        }
        onlyA = new List<X>();
        foreach (Tuple<List<X>, bool> set in mapA.Values) {
          if (!set.second) onlyA.AddRange(set.first);
        }
        return common;
    }
