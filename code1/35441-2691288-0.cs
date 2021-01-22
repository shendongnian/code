    public int Count 
    {
        get 
        { 
            //if the list hasn't been hydrated yet
            if(inner == null)
                //get the count from the IQueryable instead
                return query.Count;
            else
                return inner.Count;
        }
    }
