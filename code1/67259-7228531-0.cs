    var fileMap = new ConfigurationFileMap("pathtoconfigfile");
    var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
    var sectionGroup = configuration.GetSectionGroup("applicationSettings"); // This is the section group name, change to your needs
    var section = (ClientSettingsSection)sectionGroup.Sections.Get("MyTarget.Namespace.Properties.Settings"); // This is the section name, change to your needs
    var setting = section.Settings.Get("SettingName"); // This is the setting name, change to your needs
    return setting.Value.ValueXml.InnerText;
