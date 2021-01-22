    //Open the application level config file
    ExeConfigurationFileMap exeMap = new ExeConfigurationFileMap();
    exeMap.ExeConfigFilename = String.Format("{0}.config", 
        Context.Parameters["assemblypath"]);
    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(exeMap,
        ConfigurationUserLevel.None);
    //Get the settings section
    ClientSettingsSection settingsSection =
        config.GetSectionGroup("applicationSettings").Sections
             .OfType<ClientSettingsSection>().Single();
    //Update "TheSetting"
    //I couldn't get the changes to persist unless
    //I removed then readded the element.
    SettingElement oldElement = settingsSection.Get("TheSetting");
    settingsSection.Settings.Remove(oldElement);
    SettingElement newElement = new SettingElement("TheSetting", 
        SettingSerializeAs.String);
    newElement.Value = new SettingValueElement();
    newElement.Value.ValueXml = oldElement.Value.ValueXml.CloneNode(true);
    newElement.Value.ValueXml.InnerText = "Some New Value";
    settingsSection.Add(newElement);
    //Save the changes
    config.Save(ConfigurationSaveMode.Full);
