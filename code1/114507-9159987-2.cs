    public int? Page
    {
        get
        {
            Contract.Ensures( (result!= null).Implies(result >= 0) );
            var result = ...
    
            ...
    
    
            return result;
        }
    }
