    [TestFixture]
    public class MyTests 
    {
    private int _testId;
        
    [OneTimeSetUp]
    public void SetItUp()
    {
    ...
    _testId = whatever;
    }
    [Test]
    public void TestOne()
    {
    var whatever = _testId;
    ...
    }
    }
    
