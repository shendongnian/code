    public class ItemFuzzyMatchComparer : IEqualityComparer<string>  { 
      bool IEqualityComparer<string>.Equals(string x, string y)  { 
        return (x.Contains(y) || y.Contains(x)); 
      }  
      int IEqualityComparer<string>.GetHashCode(string obj)  { 
        if (Object.ReferenceEquals(obj, null)) return 0; 
        return 1; 
      } 
    }
