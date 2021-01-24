    public interface IRepo { }
    public interface ICsvRepo : IRepo { }
    public interface ISqlRepo : IRepo { }
    public interface IOracleRepo : IRepo { }
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
    internal class CsvRepo : ICsvRepo
    {
        private readonly ICsvSettings _settings;
        public CsvRepo(ICsvSettings settings)
        {
            _settings = settings;
        }
    }
    internal class SqlRepo : ISqlRepo
    {
        private readonly ISqlSettings _settings;
        private readonly IRepoX _repoX;
        public SqlRepo(ISqlSettings settings, IRepoX repoX)
        {
            _settings = settings;
            _repoX = repoX;
        }
    }
    internal class OracleRepo : IOracleRepo
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
                Password = "bar",
                Username = "super_bar"
            }).InSingletonScope();
            
            Bind<IRepoX>().To<RepoX>();
            Bind<ICsvRepo>().To<CsvRepo>();
            Bind<ISqlRepo>().To<SqlRepo>();
            Bind<IOracleRepo>().To<OracleRepo>();
        }
    }
