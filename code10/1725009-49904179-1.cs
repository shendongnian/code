    void Main()
    {
    	CallAB();
    	CallAC();
    }
    
    A<B> CallAB()
    {
    	return ServiceCall<A<B>>("/api/ab");
    }
    
    A<C> CallAC()
    {
    	return ServiceCall<A<C>>("/api/ac");
    }
