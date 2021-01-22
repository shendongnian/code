    public class TDecimal
    {
        private decimal? m_value;
        public bool HasValue { get { return m_value.HasValue; } }
        public decimal Value { get { return m_value.Value; } }
        public static implicit operator TDecimal(string a_value)
        {
            decimal d;
            if (decimal.TryParse(a_value, out d))
            {
                return new TDecimal() {m_value = d};
            }
            return new TDecimal() {m_value = null};
        }
        public static implicit operator decimal(TDecimal a_value)
        {
            if(a_value.HasValue)
            {
                return a_value.Value;
            }
            throw new ArgumentNullException("a_value");
        }
    }
    public class A
    {
        public TDecimal Prop { get; set; }
    }
