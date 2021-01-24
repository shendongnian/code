    class ClassUnderTest
    {
        protected readonly IApplication _application; //Injected
  
        public ClassUnderTest(IApplication application)
        {
            _application = application; //constructor injection
        }
        public void MethodUnderTest()
        {
            _application.SomeMethod("Real argument");
        }
    }
