    [CollectionDataContract(ItemName="Property")]
    public class PropertyList: List<string>
    {
        public PropertyList() { }
        public PropertyList(IEnumerable<string> source) : base(source) { }
    }
