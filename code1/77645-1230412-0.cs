    class ExposeList
    {
      private List<int> _lst = new List<int>() { 1, 2, 3 };
    
      public IEnumerable<int> ListEnumerator
      {
         get { return _lst.Select(x => x); }  // Identity transformation.
      }
    
      public ReadOnlyCollection<int> ReadOnly
      {
         get { return _lst.AsReadOnly(); }
      }
    }
