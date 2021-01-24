    public class Item
    {
        public int Id { get; set; }
        public OpenType Settings { get; set; }
    }
    public class OpenType
    {
        public IDictionary<string, object> Settings { get; set; }
    }
