    class Base {
        public string P1 { get; set; }
        public string P2 { get; set; }
    }
    
    class Limited: Base {
        new private string P1 { get; set; }
        // P2 will be inherited as public, P1 will be hidden to the user
    }
