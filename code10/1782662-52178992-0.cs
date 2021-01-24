     class myClass
     {
        public decimal Amount { get; set; }
        [JsonConstructor]
        public myClass(string amount)
        {
            this.Amount = Decimal.Parse(amount, System.Globalization.NumberStyles.Float);
        }
    }
