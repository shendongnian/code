    [TestClass]
    public class GreenCardUserTest
    {
        private readonly context;
    	[TestInitialize]
    	public Setup()
    	{
    		DbContextOptions<GreenCardContext> options;
    		var builder = new DbContextOptionsBuilder<GreenCardContext>();
    		builder.UseInMemoryDatabase();
    		var options = builder.Options;
    		context = new GreenCardContext(options);
    	}
    	
        [TestMethod]
        public void TestAddUser()
        {
            // user context here...
        }
    }
