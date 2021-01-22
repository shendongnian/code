    class myExample 
    {
      internal EventHandler eh;
    
      public event EventHandler OnSubmit 
      { 
        add 
        {
          eh = Delegate.Combine(eh, value) as EventHandler;
        }
        remove
        {
          eh = Delegate.Remove(eh, value) as EventHandler;
        }
      }
    
      ...
    }
