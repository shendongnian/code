    public class PartyTypeConverter : TypeConverter
    {
        // Implementation
    }
    [TypeConverter(typeof(PartyTypeConverter)]
    public class Party
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
