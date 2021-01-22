    public int Count 
    {
        get 
        { 
            if(inner == null)
                return query.Count;
            else
                return inner.Count;
        }
    }
