    class Record : IPEndPoint
    {
        internal long Offset { get; set; }
        public bool Deleted  { get; internal set; }
        
        public Record() : base(0, 0)
        { 
            Offset = -1;
            Deleted = false;
        }
    }
