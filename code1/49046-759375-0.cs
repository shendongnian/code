    class Building {
        private readonly List<Room> rooms = new List<Room>();
        public IList<Room> Rooms {get {return rooms;}}
        public Address Address {get;set;}
        //...
    }
    class Address {
        public string Line1 {get;set;}
        public string PostCode {get;set;}
        //...
    }
    class Room {
        public string Name {get;set;}
        public int Capacity {get;set;}
        //...
    }
