    myType<TypeA> a; // This should be a myType<TypeB>, even if it contains only TypeA's
    public void MethodB(myType<TypeB> b){ /* do stuff */ }
    public void Main()
    {
      MethodB(a);
    }
