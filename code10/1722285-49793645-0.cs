    public class TestRepository : YourProjectNameRepositoryBase<Test, int>, ITestRepository
    {
    	public TestRepository(IDbContextProvider<YourProjectNameDbContext> dbContextProvider, IObjectMapper objectMapper)
    		: base(dbContextProvider, objectMapper)
    		{
    		}
    }
