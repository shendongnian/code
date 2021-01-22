    public class ArrayListEqComp : IEqualityComparer<ArrayList>
    {//we might also implement the non-generic IEqualityComparer, omitted for brevity
      public bool Equals(ArrayList x, ArrayList y)
      {
        if(ReferenceEquals(x, y))
          return true;
        if(x == null || y == null || x.Count != y.Count)
          return false;
        for(int i = 0; i != x.Count; ++i)
          if(x[i] != y[i])
            return false;
        return true;
      }
      public int GetHashCode(ArrayList obj)
      {
        int res = 0x2D2816FE;
        foreach(var item in obj)
        {
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
      }
    }
