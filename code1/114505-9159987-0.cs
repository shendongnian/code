    public int? Page
    {
        get
        {
            var result = ...
    
            ...
    
    
            Contract.Ensures( (result!= null).Implies(result >= 0) );
            return result;
        }
    }
