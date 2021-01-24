    public class GroupComparer<T> : IEqualityComparer<Group<T>>
    {
      public bool Equals(Group<T> a, Group b<T>)
      {
        return (a.Id == b.Id);
      }
    
      public int GetHashCode(Group<T> obj)
      {
        return obj.GetHashCode();
      }
    }
