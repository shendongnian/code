    public interface IConfigurationManager {
        IConfigurableDatabase Database { get; }
        void Init();
    }
    
    public interface IConfigurableDatabase {
       string HostName { get; }
       // And the rest
    }
    
    public class ConfigurationManager 
        : IConfigurationManager, IConfigurableDatabase  {
        private static Dictionary<string, string> configDatabase = new Dictionary<string, string>();
        IConfigurableDatabase Database => this;
    
        public HostName {
            get => configDatabase["hostname"];
            set => configDatabase["hostname"] = value
        }
    }
