    [Serializable]
    public struct MyStruct: ISerializable
    {
        private readonly int _x;
        private readonly int _y;
    
        // normal constructor
        public MyStruct(int x, int y) : this()
        {
            _x = x;
            _y = y;
        }
    
        // this constructor is used for deserialization
        public MyStruct(SerializationInfo info, StreamingContext text) : this()
        {
            _x = info.GetInt32("X");
            _y = info.GetInt32("Y");
        }
    
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
    
        // this method is called during serialization
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Z", Y);
        }
    }
