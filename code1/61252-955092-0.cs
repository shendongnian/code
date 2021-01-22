    // all error checking omitted here; you would want range checks etc.
    public struct Percentage
    {
        public Percentage(decimal value) : this()
        {
            this.Value = value
        }
        public decimal Value { get; private set; }
        public static explicit operator Percentage(decimal d)
        {
            return new Percentage(d);
        }
        public static implicit operator decimal(Percentage p)
        {
            return this.Value;
        }
        public static Percentage Parse(string value)
        {
            return new Percentage(decimal.Parse(value));
        }
        public override string ToString()
        {
            return string.Format("{0}%", this.Value);
        }
    }
