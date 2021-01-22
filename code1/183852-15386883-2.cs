    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecitionAttribute : Attribute
    {
        public DecimalPrecitionAttribute(byte precition, byte scale)
        {
            Precition = precition;
            Scale = scale;
        
        }
        public byte Precition { get; set; }
        public byte Scale { get; set; }
        
    }
