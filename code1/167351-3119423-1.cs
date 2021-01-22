    public static class UnitsExtensions
    {
        public static Celsius Celsius(this Double value)
        {
            return new Celsius(value);
        }
        public static Celsius Celsius(this Single value)
        {
            return new Celsius(value);
        }
        public static Celsius Celsius(this Int32 value)
        {
            return new Celsius(value);
        }
        public static Celsius Celsius(this Decimal value)
        {
            return new Celsius((Double)value);
        }
        public static Celsius? Celsius(this Decimal? value)
        {
            return value == null ? default(Celsius?) : new Celsius((Double)value);
        }
    }
