    [DebuggerStepThrough]
    public void SomeMethod()
    {
        // lots of code...
    }
    public int SomeProperty
    {
        [DebuggerStepThrough] 
        get { return ComplexLogicConvertedToMethod(); } 
        [DebuggerStepThrough]      
        set { this.quantity = value ; }
    }
    
