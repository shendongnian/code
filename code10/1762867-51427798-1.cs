    public class MyClass
    {
        public MyClass(IDependency1 dep1, IDependency2 dep2, IDependency3 dep3)
        {}
    
        public ReturnType MyNewMethod(Tyep1 t1, Type2 t2)
        {
           //1. call to ExistingMethod1(); --> I'll just setup the return value
           //2. call to ExistingMethod2(); --> I'll just setup the return value
           //3. call using the DbContext   --> ???
           //4. call using the Logger      --> ???
        }
    }
    
        Mock<MyClass> mockedObj = new Mock<MyClass>();
        
        mockedObj.SetUp(x=>x.MyNewMethod()).Returns(objectOfReturnType);
