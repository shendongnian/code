    class ClientThread {
    public bool SomethingHasChanged;
    
      public MainLoop()
      {
        Loop {
          if (SomethingHasChanged)
          { 
            refresh();
            SomethingHasChanged = false;
          }
    
          // your business logic here
          
        } // End Loop
      }
    }
