    // this gets the applicationSettings section (and the inner section 'inoBIBooks.My.MySettings')
    Configuration config = WebConfigurationManager.OpenWebConfiguration("/" + targetvdir);
    ConfigurationSectionGroup applicationSectionGroup = config.GetSectionGroup("applicationSettings");
    ConfigurationSection applicationConfigSection = 
    applicationSectionGroup.Sections["inoBIBooks.My.MySettings"];
    ClientSettingsSection clientSection = (ClientSettingsSection)applicationConfigSection;
    // set a value to that specific property
    SettingElement applicationSetting = clientSection.Settings.Get("BIDB_Username");
    applicationSetting.Value.ValueXml.InnerText = "username";
    
    // without this, saving won't work
    applicationConfigSection.SectionInformation.ForceSave = true;
    // save
    config.Save();
