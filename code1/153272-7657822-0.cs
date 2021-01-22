    public class MyClass
    {
        public virtual string MethodA(object cmd)
        {
            return "implementation";
        }
        public string MethodB(object obj)
        {
            // do some work
            return MethodA(obj);
        }
    }
    [TestFixture]
    public class MyClassTests
    {
        [Test]
        public void MockTest()
        {
            var myClassMock = MockRepository.GenerateMock<MyClass>();
            myClassMock.Expect(x => x.MethodA("x")).Return("mock");
            Assert.AreEqual("mock", myClassMock.MethodB("x"));
            myClassMock.VerifyAllExpectations();
        }
    }
