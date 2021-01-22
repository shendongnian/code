    enum GroupTypes
    {
        TheGroup,
        TheOtherGroup
    }
    
    Dictionary<string, GroupTypes> GroupTypeLookup = new Dictionary<string, GroupTypes>();
    // initialize lookup table:
    GroupTypeLookup.Add("OEM", TheGroup);
    GroupTypeLookup.Add("CMB", TheOtherGroup);
