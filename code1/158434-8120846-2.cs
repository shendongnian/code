    public class ValueEqualList : ArrayList, IEquatable<ValueEqualList>
    {
      /*.. most methods left out ..*/
      public Equals(ValueEqualList other)//optional but a good idea almost always when we redefine equality
      {
        if(other == null)
          return false;
        if(ReferenceEquals(this, other))//identity still entails equality, so this is a good shortcut
          return true;
        if(Count != other.Count)
          return false;
        for(int i = 0; i != Count; ++i)
          if(this[i] != other[i])
            return false;
        return true;
      }
      public override bool Equals(object other)
      {
        return Equals(other as ValueEqualList);
      }
      public override int GetHashCode()
      {
        int res = 0x2D2816FE;
        foreach(var item in this)
        {
            res = res * 31 + (item == null ? 0 : item.GetHashCode());
        }
        return res;
      }
    }
