    public struct rcSpan
    {
        //C# Spec 10.4.5.1: The static field variable initializers of a class correspond to a sequence of assignments that are executed in the textual order in which they appear in the class declaration.
        internal static readonly BitVector32.Section sminSection = BitVector32.CreateSection(0x1FFF);
        internal static readonly BitVector32.Section smaxSection = BitVector32.CreateSection(0x1FFF, sminSection);
        internal static readonly BitVector32.Section areaSection = BitVector32.CreateSection(0x3F, smaxSection);
        internal BitVector32 data;
        //public uint smin : 13; 
        public uint smin
        {
            get { return (uint)data[sminSection]; }
            set { data[sminSection] = (int)value; }
        }
        //public uint smax : 13; 
        public uint smax
        {
            get { return (uint)data[smaxSection]; }
            set { data[smaxSection] = (int)value; }
        }
        //public uint area : 6; 
        public uint area
        {
            get { return (uint)data[areaSection]; }
            set { data[areaSection] = (int)value; }
        }
    }
