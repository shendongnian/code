    public class SettingGroup
    {
        public List<SettingGroup> Children { get; set; }
        
        public string Name { get; set; }
        public List<ISettingValue> Settings { get; set; }
    }
