    public class TaxRate
    {
        public readonly string Name;
        public readonly decimal Rate;
        private TaxRate(string name, decimal rate)
        {
            this.Name = name;
            this.Rate = rate;
        }
        public static readonly TaxRate NormalRate = new TaxRate("Normal rate", 20);
        public static readonly TaxRate HighRate = new TaxRate("High rate", 80);
    }
