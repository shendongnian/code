    public interface IHelloProvider
    {
        string Hello();
    }
    
    public class TestClass
    {
        private readonly IHelloProvider _provider;
    
        public TestClass(IHelloProvider provider)
        {
            _provider = provider;
        }
    
        public string Say()
        {
            return _provider.Hello();
        }
    }
    
    [TestMethod]
    public void WhenSayCallsHelloProviderAndReturnsResult()
    {
        //Given
        Mock<IHelloProvider> mock = new Mock<IHelloProvider>();
        TestClass concrete = new TestClass(mock.Object);
        //Expect
        mock.Setup(x => x.Hello()).Returns("Hello World");
        //When
        string result = concrete.Say();
        //Then
        mock.Verify(x => x.Hello(), Times.Exactly(1));
        Assert.AreEqual("Hello World", result);
    }
 
