    public partial class App : Application
    {
    	
       public static string timeZoneName { get; set; } = string.Empty;
    	
    	public App()
    	{
    		var timezone = string.Empty;
        	if (Device.RuntimePlatform == Device.Android)
        	{
            		timezone = TimeZoneInfo.Local.DisplayName;
        	}
        	else if (Device.RuntimePlatform == Device.iOS)
        	{
            		timezone = App.timeZoneName;
        	}
    	}
    
    }
