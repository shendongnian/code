    public MyClassDerived
    {
      private IInjectioned _injection;
      public MyClassDerived(IInjectioned injection)
        // Call default constructor without params
        : base()
      {
        _injection = injection;
      }
      public override void DoSomething()
      {
        _injection.DoSomething();
      }      
    }
