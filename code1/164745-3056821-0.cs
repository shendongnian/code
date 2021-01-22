    interface INamedPerson
    {
        String Name { get; }
    }
    class Bob : INamedPerson
    {
        public String Name { get; set; }
    }
    class Office
    {
        // initialisation code....
        public INamedPerson TheBoss { get; }
        public IEnumerable<INamedPerson> Minions { get; }
    }
