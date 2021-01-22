    class RoomId
    {
        private int Value {get; set;}
     
        public RoomId(int value)
        {
            this.Value = value;
        }
        
        public bool Equals(RoomId other)
        {
            return this.Value == other.Value;
        }
    }
    RoomId room1 = new RoomId(1);
    RoomId room2 = new RoomId(2);
    // To compare for equality
    bool isItTheSameRoom = room1.Equals(room2);
    // Or if you have overloaded the equality operator (==)
    bool isItTheSameRoom = room1 == room2;
