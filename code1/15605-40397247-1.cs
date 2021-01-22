    public class SomeClass
    {
    	protected int SomeMethod() {}
    }
    [TestFixture]
    public class TestClass : SomeClass{
    	
    	protected void SomeMethod2() {}
    	[Test]
    	public void SomeMethodTest() { SomeMethod2(); }
    }
