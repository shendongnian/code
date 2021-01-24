    class MyBaseClass
    {
      public virtual bool TestMethod() => false; // MUST BE VIRTUAL
    }
    class MyChildClass : MyBaseClass
    {
      public MyChildClass()
      {
        implementation = () => base.TestMethod();
      }
      private Func<bool> implementation = null;
      public override bool TestMethod() => this.implementation();
      public void SetImplementation(Func<bool> f) => this.implementation = f;
    }
