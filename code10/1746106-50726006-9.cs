    [TestFixture]
    public class UnitTest1
    {
    	[Test]
    	public void TestMethod1()
    	{
    		var repoMock = new Mock<IResourceRepository>();
    		repoMock.Setup(repository => repository.Get("foo")).Returns("My Resource Value");
    		
    		var formerStatic = new MyFormerStaticClass(repoMock.Object);
    		Console.WriteLine(formerStatic.GetText("foo"));
    	}
    }
