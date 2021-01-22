    public void C()
    {
       // Common Code goes here
    }
    
    public void C_From_A()
    {
        // Code only to be called from A() goes here.
    
        C();  // Common code executed
    }
    
    public void C_From_B()
    {
        // Code only to be called from B() goes here.
    
        C();  // Common code executed
    }
    
    
    public void A()
    {
        // Other code goes here
        
        C_From_A();
    }
