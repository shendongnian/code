    class Record : IPEndPoint
    {
        internal long Offset { get; set; }
        public bool Deleted { get; internal set; }
        
        internal Record() : base(0, 0) { }
    }
