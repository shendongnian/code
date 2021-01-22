    public IEnumerable<T> GetAllNonNullAs(this X x)
    {
        return this.Add(X.A, X.B, X.C);
    }
    
    private List<T> Add(params X[] items)
    {
       var result = new List<T>();
       foreach(var item in items)
       {
           if(item != null)
           {
               result.Add(item);
           }
       }
    }
