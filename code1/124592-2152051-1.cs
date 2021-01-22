    private int timeSinceLastPropertyAccess;
    
    public int TimeSinceLastPropertyAccess
    {
       get 
       { 
          // Reset timeSinceLastPropertyAccess to 0
          int a = timeSinceLastPropertyAccess; 
          timeSinceLastPropertyAccess = 0; 
          return a; 
       }
    }
