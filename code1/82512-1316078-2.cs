    public class RegisterCompaniesConfig
    		: ConfigurationSection
    	{
    
    		public static RegisterCompaniesConfig GetConfig()
    		{
    			return (RegisterCompaniesConfig)System.Configuration.ConfigurationManager.GetSection("RegisterCompanies") ?? new LicenceConfig();
    		}
    
    		[System.Configuration.ConfigurationProperty("Companies")]
    		public Companies Companies
    		{
    			get
    			{
    				object o = this["Companies"];
    				return o as Companies ;
    			}
    		}
    
    	}
