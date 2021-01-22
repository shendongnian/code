    class B : A 
    {
        magical public D argument; // "overrides" A.argument
    }
    class E : C {  }
    class F
    {
        public static void M(A a)
        { a.argument = new E(); }
    }
    ... 
    F(new B());
