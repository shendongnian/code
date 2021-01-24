    public SomeType GetSpecialValue(ItemType item)
    {
        if (item.AdditionalData.ContainsKey(a)) return Homeoffice;
        if (item.fields.AdditionalData.ContainsKey(b)) return ProjectIndustry;
        if (item.fields.AdditionalData.ContainsKey(c)) return ProjectCapability;
        if (item.fields.AdditionalData.ContainsKey(d)) return ProjectTopic;
        // etc
    }
    // ...
    GetProjectComponent(item, GetSpecialValue(item), rx, strNLSplitter);
    // this could need a check for situation if GetSpecialValue can also return null.
