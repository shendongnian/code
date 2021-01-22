    public IEnumerable<object> TraverseTheList()
    {
    
        foreach( object item in obj)
        {
          yield return item;
        }
        
        
    }
