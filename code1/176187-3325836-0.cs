    Func<X, object> BuildPropertyGetter<X>(string propertyName)
    {
        PropertyInfo pi = typeof(X).GetProperty(propertyName, true);
        if (pi == null) throw new ArgumentException("Type " + typeof(X).Name + " has no property named " + propertyName, propertyName);
        MethodInfo getter = pi.GetGetMethod();
        if (getter == null) throw new ArgumentException("Type " + typeof(X).Name + " has a property named " + propertyName + " but it is not readable", propertyName);
        return (Func<X, object>)Delegate.CreateDelegate(typeof (Func<X, object>), getter);
    }
    List<Tuple<X, Y>> FindCommonEntries<X, Y>(IEnumerable<X> listA, IEnumerable<Y> listB, string propertyNameA, string propertyNameB)
    {
        Func<X, object> getA = BuildPropertyGetter<X>(propertyName);
        Func<X, object> getB = BuildPropertyGetter<X>(propertyName);
        Dictionary<object, List<X>> mapA = new Dictionary<object, X>();
        foreach (X x in listA) {
          List<X> set;
          object key = getA(x);
          if (!mapA.TryGetValue(key, out set))
            mapA.Add(key, set = new List<X>());
          set.Add(x);
        }
        List<Tuple<X, Y>> common = new List<Tuple<X, Y>>();
        foreach (Y y in listB) {
          List<X> match;
          if (mapA.TryGetValue(getB(y), out match)) {
            foreach (X x in match) common.Add(x, y);
          }
        }
        return common;
    }
