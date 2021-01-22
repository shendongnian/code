    class A : B
    {
       public A() : base()
       {
          base.doSomething();
       }
    }
    
    class B : C
    {
       public B() : base()
       {
       
       }
       
       public void doSomething() { /* ... */ }
    }
    
    class C
    {
       public C() { /* ... */ }
    }
