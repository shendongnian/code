    class ListComparer:IEqualityComparer<List<int>>
    {
         public bool Equals(List<int> x, List<int> y)
         {
            if(x.Count != y.Count)
              return false;
    
            for(int i = 0; i < x.Count; i++)
              if(x[i] != y[i])
                 return false;
    
           return true;
         }
    
         public int GetHashCode(List<int> obj)
         {
            return base.GetHashCode();
         }
    }
