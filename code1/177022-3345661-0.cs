    [StructLayout(LayoutKind.Explicit)]
    public struct IntraPacketTime {
        [FieldOffset(0)]
        public UInt64 RTC;
        [FieldOffset(0)]
        public UInt32 NanoSeconds;
        [FieldOffset(4)]
        public UInt32 Seconds;
        [FieldOffset(0)]
        public UInt16 Unused;
        [FieldOffset(2)]
        public UInt16 TimeHigh;
        [FieldOffset(4)]
        public UInt16 TimeLow;
        [FieldOffset(6)]
        public UInt16 MicroSeconds;
    }
