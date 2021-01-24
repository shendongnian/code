    public class MapperProvider
    {
        public MapperProvider() { }
        public MapperConfiguration GetMapperConfig()
        {
            var mce = new MapperConfigurationExpression();
            mce.AddProfile<AutoMapperConfig>();
            var mc = new MapperConfiguration(mce);
            return mc;
        }
    }
