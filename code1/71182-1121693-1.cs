    public class EnvironmentWrapper
    {
        public virtual void Exit( int code )
        {
            Environment.Exit( code );
        }
    }
    public class MyClass
    {
        private EnvironmentWrapper Environment { get; set; }
        public MyClass() : this( null ) { }
        public MyClass( EnvironmentWrapper wrapper )
        {
            this.Environment = wrapper ?? new EnvironmentWrapper();
        }
        public void MyMethod( int code )
        {
            this.Environment.Exit( code )
        }
    }
    [TestMethod]
    public void MyMethodTest()
    {
         var mockWrapper = MockRepository.GenerateMock<EnvironmentWrapper>();
         int expectedCode = 5;
         mockWrapper.Expect( m => m.Exit( expectedCode ) );
         var myClass = new MyClass( mockWrapper );
         myclass.MyMethod( expectedCode );
         mockWrapper.VerifyAllExpectations()
    }
