    private async Task<SettingGroup> GetSettingGroup(string name)
    {
        var groupList = AppSettingProvider.Groups.Where(g => g.Name == name).ToList();
        var settingDefinitions = _settingDefinitionManager.GetAllSettingDefinitions();
        var settings = await SettingManager.GetAllSettingValuesAsync();
        return GetSettingGroupsRecursively(groupList, settingDefinitions, settings).FirstOrDefault();
    }
    private List<SettingGroup> GetSettingGroupsRecursively(IReadOnlyList<SettingDefinitionGroup> groups, IReadOnlyList<SettingDefinition> settingDefinitions, IReadOnlyList<ISettingValue> settings)
    {
        return groups
            .Select(group => new SettingGroup
            {
                Children = GetSettingGroupsRecursively(group.Children, settingDefinitions, settings),
                Name = group.Name,
                Settings = GetGroupSettings(group, settingDefinitions, settings)
            })
            .ToList();
    }
    private List<ISettingValue> GetGroupSettings(SettingDefinitionGroup group, IReadOnlyList<SettingDefinition> settingDefinitions, IReadOnlyList<ISettingValue> settings)
    {
        return settingDefinitions
            .Where(sd => sd.Group?.Name == group?.Name)
            .Select(sd => settings.Where(s => s.Name == sd.Name).FirstOrDefault())
            .Where(s => s != null)
            .ToList();
    }
