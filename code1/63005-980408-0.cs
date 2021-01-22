    class SortedHasher : SortedDictionary<int, string>
    {
       public override int GetHashCode()
       {
          int hash = 0;
          foreach(KeyValuePair<int, string> kvp in this)
          {
             hash += kvp.Key.GetHashCode() + kvp.Value.GetHashCode();
          }
          return hash;
       }
    }
