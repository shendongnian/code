    class Foo
    {
      private IBar bar= null;
    
      public Foo(IBar bar)
      {
        if(bar.X != 42) 
        {
          throw new ArgumentException("Expected Bar with X=42, but got X="+bar.X);
        }
        this.bar= bar;
      }
    
      public void DoSomething()
      {
        bar.DoIt();
      }
    }
