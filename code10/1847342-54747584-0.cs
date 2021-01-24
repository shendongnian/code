public class SomeService
{
    private readonly IDbConnection _dbCOnnection;
    public SomeService(IDbConnection dbConnection)
    {
        _dbCOnnection = dbConnection;
    }
    public async Task<IEnumerable<Foo>> GetFoos()
    {
        // Obviously don't do this in production code;
        // just for demonstration purposes.
        await _dbCOnnection.OpenAsync();
    }
}
You can implement Mock-connection classes like this:
public interface IDbConnection
{
    Task OpenAsync();
    // Other required methods...
}
public class ThrowingDbConnection : IDbConnection
{
    public Task OpenAsync()
    {
        throw new Exception("...");
    }
}
public class FakeDbConnection : IDbConnection
{
    public Task OpenAsync()
    {
        return Task.CompletedTask;
    }
}
As IoC container, you have multiple choices. Microsoft's Microsoft.Extensions.DependencyInjection, AutoFac, CastleWindsor, Ninject and so on. Pick the one that suits your needs. Most of the cases, Microsoft's or AutoFac should be good choices here.
  [1]: https://en.wikipedia.org/wiki/Interface_segregation_principle
  [2]: https://en.wikipedia.org/wiki/Dependency_inversion_principle
  [3]: https://en.wikipedia.org/wiki/Inversion_of_control
  [4]: https://en.wikipedia.org/wiki/Dependency_injection
