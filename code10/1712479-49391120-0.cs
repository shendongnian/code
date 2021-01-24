    public class Balance
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int CoinId { get; set; }
        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }
        public User User { get; set; }
    }
