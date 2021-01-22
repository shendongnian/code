    public struct rcSpan2
    {
        internal uint data;
        //public uint smin : 13; 
        public uint smin
        {
            get { return data & 0x1FFF; }
            set { data = (data & ~0x1FFFu ) | (value & 0x1FFF); }
        }
        //public uint smax : 13; 
        public uint smax
        {
            get { return (data >> 13) & 0x1FFF; }
            set { data = (data & ~(0x1FFFu << 13)) | (value & 0x1FFF) << 13; }
        }
        //public uint area : 6; 
        public uint area
        {
            get { return (data >> 26) & 0x3F; }
            set { data = (data & ~(0x3F << 26)) | (value & 0x3F) << 26; }
        }
    }
