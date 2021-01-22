    	System.Collections.Specialized.ListDictionary lstSettings;
    	string msg; 
    
    	MyApp.Bo.AppUser objAppUser = new AppUser();
    	MyApp.Db.SqlServer2008Provider p = new MyApp.Db.SqlServer2008Provider(objAppUser);
    	
    	
    
    	p.LoadSettings(out msg, out lstSettings); 
    
    	foreach (string key in lstSettings.Keys)
    	{
    
    		string name = key;
    		string value = (string)lstSettings[key];
    
    		#region CycleTroughobjAppSettingProperties
    		Type objAppSettingsType = typeof(MyApp.Bo.AppSettings);
    		foreach (PropertyInfo propInfo in objAppSettingsType.GetProperties())
    		{
    			if (propInfo.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
    			{
    				
    				try
    				{
    					propInfo.SetValue(this, Convert.ChangeType(value, propInfo.PropertyType, CultureInfo.CurrentCulture), null);
    				}
    				catch
    				{
    					logger.Fatal("Failed setting the Application settings ");
    				}
    				break;
    			}
    		}
    		#endregion CycleTroughobjAppSettingProperties
    	}
    
    
