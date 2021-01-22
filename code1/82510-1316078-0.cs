    public class Company :ConfigurationElement
    {
    
    		[ConfigurationProperty("name", IsRequired = true)]
    		public string Name
    		{
    			get
    			{
    				return this["name"] as string;
    			}
    		}
                [ConfigurationProperty("code", IsRequired = true)]
    		public string Code
    		{
    			get
    			{
    				return this["code"] as string;
    			}
    		}
    }
