    public class SomeClass
    {
    	private int SomeMethod() {}
    }
    [TestFixture]
    public class TestClass : SomeClass{
    	[Test]
    	private void SomeMethodTest() {}
    }
