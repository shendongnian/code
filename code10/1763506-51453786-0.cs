    public interface IStateRepository
    {
    }
    public class LocalRepository : IStateRepository
    {
    }
    public class DapperRepository : IStateRepository
    {
    }
    services.AddTransient<IStateRepository, LocalRepository>()
            .AddTransient<IStateRepository, DapperRepository>()
            .AddTransient<StateRepositories>();
    public class StateRepositories
    {
        public IStateRepository Local { get; }
        public IStateRepository SqlServer { get; }
        public StateRepositories(IEnumerable<IStateRepository> repositories)
        {
            Local = repositories.OfType<LocalRepository>().FirstOrDefault();
            SqlServer = repositories.OfType<DapperRepository>().FirstOrDefault();
        }
    }
