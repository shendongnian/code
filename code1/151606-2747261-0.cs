    class MyBase
    {
      // Only if need to do some core initialization
      public MyBase()
      {
      }
    
      public virtual Initialize()
      {
        // do some initialization stuff here
      }
    }
    
    class MyDerived : MyBase
    {
      // Only if need to do some core initialization
      public MyDerived()
      {
      }
    
      public override Initialize()
      {
        // do some initialization stuff here
    
        // Call the base class initialization function
        base.Initialize();
      }
    }
