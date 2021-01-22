    public Number : INumber
    {
        private decimal value = 0m;
        private int thousands = 0;
        public void Add1000()
        {
            thousands++;
        }
        void SetValue(decimal d)
        {
            value = d;
            thousands = 0;
        }
        decimal GetValue()
        {
            // Careful of the overflow... (do multiplication in decimal)
            value += thousands * 1000m;
            thousands = 0;
            return value;
        }
    }
