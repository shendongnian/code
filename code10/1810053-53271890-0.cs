    public class Payload
    {
        public Dictionary<string, Item> Addresses { get; set; }
    }
    public class Item
    {
        public string BodyOverride { get; set; }
        public string ChannelType { get; set; }
    }
