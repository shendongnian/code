    class Money {
        public decimal Amount { get; set; }
        public Money(decimal amount) {
            Amount = amount;
        }
        public static implicit operator Money(decimal amount) {
            return new Money(amount);
        }
    }
