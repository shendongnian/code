    public sealed class NameAndAddress
    {
        private readonly string name;
        public string Name { get { return name; } }
        private readonly string address;
        public string Address { get { return address; } }
        public NameAndAddress(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
    }
