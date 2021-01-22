    struct DictEntry
    {
        public SettingType Key;        
        [XmlElement("SubSettingValue", Type=typeof(SubSettings))]        
        [XmlElement("CoolSubSettingValue", Type=typeof(CoolSubSettings))]
        public object Value;
    }
    
    [XmlArray("SubSettings")]
    public DictEntry[] _SubSettings
    {
        // ...
