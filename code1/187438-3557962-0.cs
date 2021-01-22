    [TestFixture]
    public class BaseFixtureTests
    {
        protected IMyClass _myClass;
    
        [TestFixtureSetUp]
        public void FixtureSetup() 
        {
            _myClass = ConfigureMyClass();
        }
    
        protected virtual IMyClass ConfigureMyClass() 
        {
            // fixtures that inherit from this will set up _myClass here as they see fit.
        }
    
        [Test]
        public void MyClassTest1() 
        {
            // test something about _myClass;
        }
    }
    
    [TestFixture]
    public class MySpecificFixture1 : BaseFixtureTests
    {
        protected override IMyClass ConfigureMyClass()
        {
            return new MySpecificMyClassImplementation();
        }   
    }
    public class MySpecificMyClassImplementation : IMyClass
    {
        //some implementation
    }
