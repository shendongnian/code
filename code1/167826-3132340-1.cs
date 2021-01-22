    public void FooBar() 
    { 
        object foo = null; 
        object bar = null; 
     
        try 
        { 
           foo = new object(); 
           bar = new object(); 
     
           // Code which throws exception. 
        } 
        finally 
        { 
           // Destroying objects 
           foo = null; 
           bar = null; 
        } 
        vavoom(foo,bar);
    } 
