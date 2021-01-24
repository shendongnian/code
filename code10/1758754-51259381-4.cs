    public sealed class Customer
    {
        private readonly Func<string> _loadLogbook;
        public Customer(string name, Func<string> logbook)
        {
            Name = name;
            _loadLogbook = logbook;
        }
        public string Name { get; }
        public string Logbook => _loadLogbook();
    }
