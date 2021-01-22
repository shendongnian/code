    interface IMap
    {
        int Size { get; set; }
    }
    struct Map: IMap
    {
        public Map(int size)
        {
            _size = size;
        }
        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        
        public override string ToString()
        {
            return String.Format("Size: {0}", this.Size);
        }
    }
