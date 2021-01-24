    public struct DosDateTime
    {
        public ushort Date;
        public ushort Time;
        public int Year
        {
            get => ((Date >> 9) & 0x7F) + 1980;
            set => Date = (ushort)((Date & 0x1FF) | ((value - 1980) << 9));
        }
        public int Month
        {
            get => (Date >> 5) & 0xF;
            set => Date = (ushort)((Date & 0xFE1F) | (value<< 5));
        }
        public int Day
        {
            get => Date & 0x1F;
            set => Date = (ushort)((Date & 0xFFE0) | value);
        }
        public int Hour
        {
            get => (Time >> 11) & 0x1F;
            set => Time = (ushort)((Time & 0x7FF) | (value << 11));
        }
        public int Minute
        {
            get => (Time >> 5) & 0x3F;
            set => Time = (ushort)((Time & 0xF81F) | (value << 5));
        }
        public int Second
        {
            get => (Time & 0x1F) << 1;
            set => Time = (ushort)((Time & 0xFFE0) | (value >> 1));
        }
    }
