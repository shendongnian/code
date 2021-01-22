    public static void LoadFrom(this ApplicationSettingsBase settings, NameValueCollection configuration)
    {
        if (configuration != null)
            foreach (string key in configuration.AllKeys)
                if (!String.IsNullOrEmpty(key))
                    try
                    {
                        settings[key] = configuration.Get(key);
                    }
                    catch (SettingsPropertyNotFoundException)
                    {
                      // handle bad arguments as you wish
                    }
    }
