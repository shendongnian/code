    class Client
    {
        public Client()
        {
            Clients = new List<Client>();
        }
        public List<Client> Clients { get; private set; }
        private int aCClientID;
        public int ACClientID
        {
            get { return aCClientID; }
            set { aCClientID = value; }
        }
        public int ACClientIDRecursive
        {
            get
            {
                return aCClientID;
            }
            set
            {
                aCClientID = value;
                foreach (var c in Clients)
                {
                    c.ACClientIDRecursive = value;
                }
            }
        }
    }
