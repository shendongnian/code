    public struct MyStruct
    {
        private readonly ReadOnlyCollection<int> _myInts;
    
        public MyStruct(ReadOnlyCollection<int> ints)
        {
            _myInts = ints;
        }
    }
