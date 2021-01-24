    public class ConfigurationRepository : IConfigurationRepository {
        private Lazy<Settings> settings = new Lazy<Settings>(() => new Settings());
    
        public virtual Settings AppSettings {
            get { return settings.Value; }
        }
    }
