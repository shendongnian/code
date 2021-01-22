    using System;
    using System.Collections.Generic;
    
    public class DeepCopy
    {
      public static Dictionary<T1, T2> CloneKeys<T1, T2>(Dictionary<T1, T2> dict)
        where T1 : ICloneable
      {
        if (dict == null)
          return null;
        Dictionary<T1, T2> ret = new Dictionary<T1, T2>();
        foreach (var e in dict)
          ret[(T1)e.Key.Clone()] = e.Value;
        return ret;
      }
    
      public static Dictionary<T1, T2> CloneValues<T1, T2>(Dictionary<T1, T2> dict)
        where T2 : ICloneable
      {
        if (dict == null)
          return null;
        Dictionary<T1, T2> ret = new Dictionary<T1, T2>();
        foreach (var e in dict)
          ret[e.Key] = (T2)(e.Value.Clone());
        return ret;
      }
    
      public static Dictionary<T1, T2> Clone<T1, T2>(Dictionary<T1, T2> dict)
        where T1 : ICloneable
        where T2 : ICloneable
      {
        if (dict == null)
          return null;
        Dictionary<T1, T2> ret = new Dictionary<T1, T2>();
        foreach (var e in dict)
          ret[(T1)e.Key.Clone()] = (T2)(e.Value.Clone());
        return ret;
      }
    }
