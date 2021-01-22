    private void UpdateAppSettings(string theKey, string theValue)
    		{
    			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    			if (ConfigurationManager.AppSettings.AllKeys.Contains(theKey))
    			{
    				configuration.AppSettings.Settings[theKey].Value = theValue;
    			}
    
    			configuration.Save(ConfigurationSaveMode.Modified);
    
    			ConfigurationManager.RefreshSection("appSettings");
    		}
