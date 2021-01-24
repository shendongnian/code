    public class Contact
    {
        public string Id      { get; set; }
        public string Name    { get; set; }
        public string Address { get; set; }
        public string Phone   { get; set; }
        public Dictionary<string, object> CustomFields { get; set; }
    }
    public class CustomField
    {
        public string Id          { get; set; }
        public string Code        { get; set; }
        public string DataType    { get; set; }
        public string Description { get; set; }
    }
