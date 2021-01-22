    public bool ContainsAll(List<T> a,List<T> check)
    {
       list l = new List<T>(check);
       foreach(T _t in a)
       {
          if(check.Contains(t))
          {
             check.Remove(t);
             if(check.Count == 0)
             {
                return true;
             }
          }
          return false;
       }
    }
