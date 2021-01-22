    public class MyObject : IComparable<MyObject>
    {
    public int First;
    public int Second;
    public int CompareTo(MyObject other)
    {
      if (Equals(this, other))
      {
        return 0;
      }
      if (ReferenceEquals(other, null))
      {
        return 1;
      }
      int first = this.First.CompareTo(other.First);
      if (first != 0)
      {
        return first;
      }
      return this.Second.CompareTo(other.Second);
    }
    }
