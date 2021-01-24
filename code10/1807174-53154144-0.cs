    class Wrapper
    {
        public TypeA A {get;}
        public TypeB B {get;}
        public TypeC C {get;}
    
      public Wrapper(TypeA A, TypeB B, TypeC C)
      {
       this.A = A ?? throw new ArgumentNullException(nameof(A));
       this.B = B ?? throw new ArgumentNullException(nameof(B));
       this.C = C ?? throw new ArgumentNullException(nameof(C));
      }
    }
