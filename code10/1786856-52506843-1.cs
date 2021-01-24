    private void SaveGroup2()
    {
        var config = GetConfig();
        var root = config.SectionGroups[ROOT_GROUP];
        var existingGroups = new Dictionary<string, ConfigurationSectionGroup>();
        while (root.SectionGroups.Count > 0)
        {
            existingGroups.Add(root.SectionGroups.Keys[0], root.SectionGroups[0]);
            root.SectionGroups.RemoveAt(0);
        }
    
        config.Save(ConfigurationSaveMode.Modified);
    
        existingGroups.Add(GROUP_2, new UserSettingsGroup());
        foreach (var key in existingGroups.Keys)
        {
            existingGroups[key].ForceDeclaration(true);
            root.SectionGroups.Add(key, existingGroups[key]);
        }
    
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection(root.Name);
    }
