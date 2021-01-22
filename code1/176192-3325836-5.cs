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
    public class Pair<S,T>
    {
       public readonly S first;
       public readonly T second;
       public Pair(S s, T t) { first = s; second = t; }
    }
    List<Pair<X, Y>> FindCommonEntries<X, Y>(IEnumerable<X> listA, IEnumerable<Y> listB, string propertyNameA, string propertyNameB, out List<X> onlyA, out List<Y> onlyB)
    {
        return FindCommonEntries<X,Y>(listA, listB, PropertyGetter<X>[propertyName], PropertyGetter<Y>[propertyName], out onlyA, out onlyB);
    }
    List<Pair<X, Y>> FindCommonEntries<X, Y>(IEnumerable<X> listA, IEnumerable<Y> listB, Converter<X, object> getA, Converter<Y, object> getB, out List<X> onlyA, out List<Y> onlyB)
    {
        Dictionary<object, Pair<List<X>, bool>> mapA = new Dictionary<object, X>();
        foreach (X x in listA) {
          Pair<List<X>,bool> set;
          object key = getA(x);
          if (!mapA.TryGetValue(key, out set))
            mapA.Add(key, set = new Pair<List<X>, bool>(new List<X>(), false));
          set.first.Add(x);
        }
        onlyB = new List<Y>();
        List<Pair<X, Y>> common = new List<Pair<X, Y>>();
        foreach (Y y in listB) {
          Pair<List<X>,bool> match;
          if (mapA.TryGetValue(getB(y), out match)) {
            foreach (X x in match.first) common.Add(x, y);
            match.second = true;
          }
          else
            onlyB.Add(y);
        }
        onlyA = new List<X>();
        foreach (Pair<List<X>, bool> set in mapA.Values) {
          if (!set.second) onlyA.AddRange(set.first);
        }
        return common;
    }
