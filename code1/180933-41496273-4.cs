    public class Weight
    {
        private readonly Decimal _value;
        public Weight(Decimal value)
        {
            _value = value;
        }
        public static explicit operator Weight(Decimal value)
        {
            return new Weight(value);
        }
        public static explicit operator Decimal(Weight value)
        {
            return value._value;
        }
    };
     public class Price {
        private readonly Decimal _value;
        public Price(Decimal value) {
            _value = value;
        }
        public static explicit operator Price(Decimal value) {
            return new Price(value);
        }
        public static explicit operator Decimal(Price value)
        {
            return value._value;
        }
    };
