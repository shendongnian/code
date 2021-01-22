    class B : A 
    {
        override public D argument; // "overrides" A.argument
    }
    class E : C {  }
    class F
    {
        public static void M(A a)
        { a.argument = new E(); }
    }
    ... 
    F.M(new B());
