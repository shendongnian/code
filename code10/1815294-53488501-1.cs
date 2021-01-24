    class A
    {
      public B classB { get; set; }
      public void funcIHaveToUseInClassB()
      {
      }
      public void anotherF()
      {
         classB.funcIHaveToUseInClassA();
      }
    }
    class B
    {
       public A classA { get; set; }
       public void funcIHaveToUseInClassA() 
       {
       }
       public void anotherF()
       {
          classA.funcIHaveToUseInClassB();
       }
    }
  
    static void main()
    {
        // entry point
        var a = new A();
        var b = new B();
        a.classB = b;
        b.classA = a;
        // do what ever you want with a and b
    }
