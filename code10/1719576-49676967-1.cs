    class RootJson
    {
        public Dictionary<int, Property> Http { get; set; }
        public Dictionary<int, Property> Sip { get; set; }
    }
    
    class Root
    {
        // TODO: Control access more :)
        public Property[] Http { get; set; }
        public Property[] Sip { get; set; }
    }
