    [TestFixture]
    public class UnitTest1
    {
    	[Test]
    	public void TestMethod1()
    	{
    		var foo = new Mock<IResourceRepository>();
    		foo.Setup(repository => repository.Get("foo")).Returns("My Resource Value");
    		
    		var formerStatic = new MyFormerStaticClass(foo.Object);
    		Console.WriteLine(formerStatic.GetText("foo"));
    	}
    }
