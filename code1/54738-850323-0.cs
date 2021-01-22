    class RoomId
    {
        private Value {get; set;}
     
        public RoomId(int value)
        {
            this.Value = value;
        }
        
        public bool Equals(RoomId other)
        {
            return this.Value == other.Value;
        }
    }
