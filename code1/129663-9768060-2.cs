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
    /// <returns>result: true\false</returns>
    public bool ChangePolicyUser(string gpoName, string keyPath, RegistryValueKind typeOfKey, string parameterName, object value)
        {
            try
            {
                RegistrySetting newSetting = new PolicyRegistrySetting();
                newSetting.Hive = RegistryHive.CurrentUser;
                newSetting.KeyPath = keyPath;
                bool contains = false;
                //newSetting.SetValue(parameterName, value, typeOfKey);
                switch (typeOfKey)
                {
                    case RegistryValueKind.String:
                        newSetting.SetValue(parameterName, (string)value, typeOfKey);
                        break;
                    case RegistryValueKind.ExpandString:
                        newSetting.SetValue(parameterName, (string)value, typeOfKey);
                        break;
                    case RegistryValueKind.DWord:
                        newSetting.SetValue(parameterName, (Int32)value);
                        break;
                    case RegistryValueKind.QWord:
                        newSetting.SetValue(parameterName, (Int64)value);
                        break;
                    case RegistryValueKind.Binary:
                        newSetting.SetValue(parameterName, (byte[])value);
                        break;
                    case RegistryValueKind.MultiString:
                        newSetting.SetValue(parameterName, (string[])value, typeOfKey);
                        break;
                }
                Gpo gpoTarget = _gpDomain.GetGpo(gpoName);
                RegistryPolicy registry = gpoTarget.User.Policy.GetRegistry(false);
                try
                {
                    ReadOnlyCollection<RegistryItem> items = gpoTarget.User.Policy.GetRegistry(false).Read(newSetting.Hive, keyPath);
                    foreach (RegistryItem item in items)
                    {
                        if (((RegistrySetting) item).ValueName == parameterName)
                        {
                            contains = true;
                        }
                    }
                    registry.Write((PolicyRegistrySetting) newSetting, !contains);
                    registry.Save(false);
                    return true;
                }
                catch (ArgumentException)
                {
                    registry.Write((PolicyRegistrySetting)newSetting, contains);
                    registry.Save(true);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
