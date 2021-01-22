    class A
    {
      public A(A copy) {}
    }
    
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
        copy.A = new A(this.A);
        copy.B = this.B.Copy();
      }
    }
