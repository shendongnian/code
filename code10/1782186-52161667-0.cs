    class NewService : IService
    {
        public int Calculate(int userId, Configuration configuration)
        {
            var extendedConfig = new ExtendedConfiguration {
                Max = configuration.Max,
                Min=configuration.Min
            };
            
            return e.Max - e.Min;
        }
    }
