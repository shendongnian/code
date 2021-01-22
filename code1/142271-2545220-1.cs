    class A
    {
      // copy constructor
      public A(A copy) {}
    }
    
    // a referenced class implementing 
    class B : IDeepCopy
    {
      object Copy() { return new B(); }
    }
    
    class C : IDeepCopy
    {
      A A;
      B B;
      object Copy()
      {
        C copy = new C();
        // copy property by property in a appropriate way
        copy.A = new A(this.A);
        copy.B = this.B.Copy();
      }
    }
