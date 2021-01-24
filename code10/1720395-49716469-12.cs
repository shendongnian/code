    public class CustomMailConfigSource: IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _dbOptions;
        public CustomMailConfigSource(Action<DbContextOptionsBuilder> dbOptions)
        {
            _dbOptions = dbOptions;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CustomMailConfigProvider(_dbOptions);
        }
    }
