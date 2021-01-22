    void Main()
    {
    	var el = new ExposeList();
    	var lst = el.ListEnumerator;
    	var oops = (IList<int>)lst;
    	oops.Add( 4 );  // mutates list
    	
    	var rol = el.ReadOnly;
    	var oops2 = (IList<int>)rol;
    	
    	oops2.Add( 5 );  // raises exception
    }
    
    class ExposeList
    {
      private List<int> _lst = new List<int>() { 1, 2, 3 };
      
      public IEnumerable<int> ListEnumerator
      {
         get { return _lst; }
      }
      
      public ReadOnlyCollection<int> ReadOnly
      {
         get { return _lst.AsReadOnly(); }
      }
    }
