            // Add an entry to appSettings section.
            int appStgCnt =
                ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();
    
            string newValue = DateTime.Now.ToLongDateString() +
              " " + DateTime.Now.ToLongTimeString();
    
            config.AppSettings.Settings.Add(newKey, newValue);
    config.Save(ConfigurationSaveMode.Full);
