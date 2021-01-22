    struct MyStruct
    {
        private byte _X;
        private byte _Y;
        public MyStruct(byte x, byte y)
        {
            _X = x;
            _Y = y;
        }
        public byte X { get { return _X; } }
        public byte Y { get { return _Y; } }
        private static Dictionary<MyStruct, Color> _ColorMap;
        static MyStruct()
        {
            _ColorMap = new Dictionary<MyStruct, Color>();
            // read color mapping from somewhere...perhaps a file specific to the type of LED
        }
        public Color GetColor()
        {
            return _ColorMap[this];
        }
    }
