    public class GroupComparer<T> : IEqualityComparer<Group<T>> where T : CustomGroup
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
