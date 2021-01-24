    public class People
    {
        public bool IsSingleAccount { get; set; }
        public string State { get; set; }
    
        private string _address;
        public string Address
        {
            set => _address = value;
            get => IsSingleAccount ? State : _address;
        }
    }
