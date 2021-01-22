    using System;
    using System.Linq;
    using System.Reflection;
    
    public class Application
    {
    	static DateTime BuildDate;
    	public static DateTime GetBuildDate()
    	{
    		if (BuildDate == default(DateTime)) {
    			var attr = typeof(Application).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>();
    			var dateStr = attr.Single(a => a.Key == "AssemblyDate")?.Value;
    			BuildDate = DateTime.Parse(dateStr);
    		}
    		return BuildDate;
    	}
    }
