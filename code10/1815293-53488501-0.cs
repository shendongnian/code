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
        // possibly main function of you program
        var a = new A();
        var b = new B();
        a.classB = b;
        b.classA = a;
    }
