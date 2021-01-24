    public interface IRepo { }
    public interface IRepository<T> : IRepo where T : class {}
    public interface ICsvRepo<T> : IRepository<T> where T : class { }
    public interface ISqlRepo<T> : IRepository<T> where T : class { }
    public interface IOracleRepo<T> : IRepository<T> where T : class { }
    public interface IRepoX : IRepo { }
    public interface ICsvSettings
    {
        string Path { get; }
        string FileName { get; }
    }
    public interface ISqlSettings
    {
        string ConnectionString { get; }
        string Username { get; }
        string Password { get; }
    }
    internal class CsvSettings : ICsvSettings
    {
        public string Path { get; set; }
        public string FileName { get; set; }
    }
    internal class SqlSettings : ISqlSettings
    {
        public string ConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    internal class CsvRepo<T> : ICsvRepo<T> where T : class
    {
        private readonly ICsvSettings _settings;
        public CsvRepo(ICsvSettings settings)
        {
            _settings = settings;
        }
    }
    internal class SqlRepo<T> : ISqlRepo<T> where T : class
    {
        private readonly ISqlSettings _settings;
        private readonly IRepoX _repoX;
        public SqlRepo(ISqlSettings settings, IRepoX repoX)
        {
            _settings = settings;
            _repoX = repoX;
        }
    }
    internal class OracleRepo<T> : IOracleRepo<T> where T : class
    {
        private readonly ISqlSettings _settings;
        private readonly IRepoX _repoX;
        public OracleRepo(ISqlSettings settings, IRepoX repoX)
        {
            _settings = settings;
            _repoX = repoX;
        }
    }
    internal class RepoX : IRepoX { }
    public class RepoModule : NinjectModule
    {
        private readonly string _username;
        private readonly string _password;
        public RepoModule(string username, string password)
        {
             _username = username;
             _password = password;
        }
        public override void Load()
        {
            Bind<ICsvSettings>().ToConstant(new CsvSettings
            {
                FileName = "foo",
                Path = "bar"
            }).InSingletonScope();
            Bind<ISqlSettings>().ToConstant(new SqlSettings
            {
                ConnectionString = "foo",
                Password = _password,
                Username = _username
            }).InSingletonScope();
            
            Bind<IRepoX>().To<RepoX>();
            Bind(typeof(ICsvRepo<>)).To(typeof(CsvRepo<>));
            Bind(typeof(ISqlRepo<>)).To(typeof(SqlRepo<>));
            Bind(typeof(IOracleRepo<>)).To(typeof(OracleRepo<>));
        }
    }
