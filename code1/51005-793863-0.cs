    using NUnit.Framework;
    using System.Diagnostics;
    
    [TestFixture]
    public class MyTestClass {
    	[Test]
    	public void SayHello() {
    		string greet = "Hello World!";
    		Debug.WriteLine(greet);
    		Assert.AreEqual("Hello World!", greet);
    	}
    }
