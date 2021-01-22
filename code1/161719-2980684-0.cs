    public class PersonBO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<AddressBO> Addresses { get; set; }
    }
