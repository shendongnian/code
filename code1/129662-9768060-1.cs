    using System.Collections.ObjectModel;
    using Microsoft.GroupPolicy;
    using Microsoft.Win32;
    
    /// <summary>
    /// Change user's registry policy
    /// </summary>
    /// <param name="gpoName">The name of Group Policy Object(DisplayName)</param>
    /// <param name="keyPath">Is KeyPath(like string path=@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")</param>
    /// <param name="typeOfKey">DWord, ExpandString,... e.t.c </param>
    /// <param name="parameterName">Name of parameter</param>
    /// <param name="value">Value</param>
    /// <returns>Результат операции true\false</returns>
    public bool ChangePolicyUser(string gpoName, string keyPath, RegistryValueKind typeOfKey, string parameterName, string value)
    {
    	GPDomain _gpDomain = new GPDomain(Domain.GetComputerDomain());
    	try
    	{
    		bool contains = false;
    		RegistrySetting newSetting = new PolicyRegistrySetting();
    		newSetting.Hive = RegistryHive.CurrentUser;
    		newSetting.KeyPath = keyPath;
    		newSetting.SetValue(parameterName, value, typeOfKey);
    		Gpo gpoTarget = _gpDomain.GetGpo(gpoName);
    		RegistryPolicy registry = gpoTarget.User.Policy.GetRegistry(false);
    		ReadOnlyCollection<RegistryItem> items = gpoTarget.User.Policy.GetRegistry(false).Read(newSetting.Hive, keyPath);
    		foreach (RegistryItem item in items)
    		{
    			if (((RegistrySetting)item).ValueName == parameterName)
    			{
    				contains = true;
    			}
    		}
    		if (contains)
    		{
    			registry.Write((PolicyRegistrySetting)newSetting, false);
    		}
    		else
    		{
    			registry.Write((PolicyRegistrySetting)newSetting, true);
    		}
    		registry.Save(false);
    		return true;
    	}
    	catch (Exception)
    	{
    		return false;
    	}
    }
