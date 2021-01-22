    public xyz (int? a)
    {
      if (a.hasvalue)
      { 
        blah = DoSomething((int)a);
        // or without a cast  as other noted:
        blah = DoSomething(a.Value);
