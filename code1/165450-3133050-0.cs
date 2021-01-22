    public interface IConfigurationProvider<TConfiguration>
    {
        TConfiguration GetConfiguration();
    }
    public class BasicConfigurationProvider : IConfigurationProvider<IBasicConfiguration>
    {
        public IBasicConfiguration GetConfiguration()
        {
            return (BasicConfigurationSection)ConfigurationManager.GetSection("Our/Xml/Structure/BasicConfiguration");
        }
    }
