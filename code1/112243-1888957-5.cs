    public class StaticConfigReader : IConfigReader
    {
    	public string Get(string key)
    	{
    		return ConfigurationManager.AppSetting[key];
    	}
    }
