    public interface IConfigurationService
    {
        string ConnectionString {get;}
    }
    public class ConfigurationService : IConfigurationService
    {
        string ConnectionString {get;}
        public ConfigurationService()
        {
            // load configuration
        }
    }
