    public class Price
    {
        [JsonConstructor]
        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
    }
