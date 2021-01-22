    public class MyClass
    {
        // ...
    }
    // In a different assembly:
    [TestFixture]
    public class TestMyClass
    {
        [SetUp]
        public void SetUp()
        {
            _myClass = new MyClass();
        }
        [Test]
        public void FooReturnsTrue()
        {
            Assert.That(_myClass.Foo(), Is.True);
        }
        // more tests
        private MyClass _myClass;
    }
