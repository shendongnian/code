    private class Comp : IEqualityComparer<Item>
        {
          public bool Equals(Item x, Item y)
          {
            var equalityOfB = x.ID2 == y.ID2;
            if (x.ID1 == y.ID1 && equalityOfB)
              return true;
            if (x.ID1 == null && equalityOfB)
            {
              x.ID1 = y.ID1;
              return true;
            }
            if (y.ID1 == null && equalityOfB)
            {
              y.ID1 = x.ID1;
              return true;
            }
            return false;
          }
    
          public int GetHashCode(Item obj)
          {
            return obj.ID2.GetHashCode();
          }
        }
