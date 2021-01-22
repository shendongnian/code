    public void TestConcreteAFoo() {
       IFoo aFoo = new ConcreteAFoo(param1, param2, param3);
       
       GenericIFooTest(aFoo);
    }
    public void TestConcreteBFoo() {
       IFoo bFoo = new ConcreteBFoo();
    
       GenericIFooTest(bFoo);
    }
