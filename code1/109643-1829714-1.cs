    struct RoundedDecimal
    {
        public decimal Value { get; private set; }
    
        public RoundedDecimal(decimal value) : this()
        {
            this.Value = value;
        }
    
        public static implicit operator decimal(RoundedDecimal d)
        {
            return Math.Round(d.Value);
        }
    }
