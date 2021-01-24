    public void Method1(IEnumerable<IX> arg)
    {
        var filtered = arg.OfType<X2>();
        Method2(filtered);
    }
    
    public void Method2(IEnumerable<X2> arg) 
    {
        
    }
