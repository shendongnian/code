    public IEnumerable<SomeType> GetSpecialValues(ItemType item)
    {
        if (item.AdditionalData.ContainsKey(a)) yield return Homeoffice;
        if (item.fields.AdditionalData.ContainsKey(b)) yield return ProjectIndustry;
        if (item.fields.AdditionalData.ContainsKey(c)) yield return ProjectCapability;
        if (item.fields.AdditionalData.ContainsKey(d)) yield return ProjectTopic;
        // etc
    }
    // ...
    foreach (var value in GetSpecialValues(item))
    {
        GetProjectComponent(item, value, rx, strNLSplitter);
    }
