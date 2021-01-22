    /// <summary>
    /// In memory storage of the settings values
    /// </summary>
    private Dictionary<string, SettingStruct> SettingsDictionary { get; set; }
    
    /// <summary>
    /// Helper struct.
    /// </summary>
    internal struct SettingStruct
    {
        internal string name;
        internal string serializeAs;
        internal string value;
    }
