    struct MyStruct
    {
        public byte X;
        public byte Y;
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
