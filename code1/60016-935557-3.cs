    void Scenario1a()
    {
       try
       {
          Scenario1b();
       }
       catch (..) { ... }    
    
    }
    
    void Scenario1b()
    {
         var x = new SuspectType();
         ...
    }
