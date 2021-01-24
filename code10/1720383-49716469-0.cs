    public class CustomMailConfigSource: IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _dbOptions;
        public EFConfigSource(Action<DbContextOptionsBuilder> dbOptions)
        {
            _dbOptions = dbOptions;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CustomMailConfigProvider(_dbOptions);
        }
    }
