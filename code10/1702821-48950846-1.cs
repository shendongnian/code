    public class Sample : ISomeInterface
    {
       public virtual string GetSomething()
        {
            return "HELLO";
        }
    
        public string MethodToTest()
        {
            return GetSomething();
        }
    }
    
    ...
    
    var mockSample = new Mock<Sample>();
    mockSample.Setup(s => s.GetSomething()).Returns("mystring");
    Assert.Equal("mystring", s.MethodToTest());
