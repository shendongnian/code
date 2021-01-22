      public ClassA()
      {
        SetStuff(); 
        _methodA = this; 
      }
      public ClassA(IMethodA methodA)
      {
        SetStuff(); 
        _methodA = methodA;
      }
