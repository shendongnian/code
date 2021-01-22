    public class ClassRequiringConfig
    {
    	public void MethodUsingConfig()
    	{
    		string setting = this.GetConfigReader().GetAppSetting("key");
    	}
    	protected virtual IConfigReader GetConfigReader()
    	{
    		return new StaticConfigReader();
    	}
    }
