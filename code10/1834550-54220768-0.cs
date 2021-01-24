cs
AddConfigurationSetting("MicrosoftAppId", appId);
AddConfigurationSetting("MicrosoftAppPassword", appPassword);
private static void AddConfigurationSetting(string name, string value)
{
	if (!ConfigurationManager.AppSettings.AllKeys.Contains(name))
    {
	    ConfigurationManager.AppSettings[name] = value;
	}
}
