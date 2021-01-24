    // StringResources is my ResourceManager object which is generated during adding .Resx file in solution
    string displayname = GetName(MyEnum.SomeType.ToString(), StringResources)
    public string GetName(string key, ResourceManager resourceManager)
    {
        string displayName = resourceManager.GetString(key);
        if (string.IsNullOrEmpty(displayName))
            displayName = key;
        return displayName;
    }
