    class foo : Ibarrable, Ibazzable
    {
      ... 
      public Bar TheBar{ set }
      public Baz TheBaz{ set }
    
      public void BarFunction()
      {
         TheBar.doSomething();
      }
      public Thing BazFunction( object param )
      {
        return TheBaz.doSomethingComplex(param);
      }
    }
     
