    public class QuoteRate
    {
        private Quote _quote;
        private Rate _rate;
        public QuoteRate(Quote quote, Rate rate)
        {
            _quote = quote;
            _rate = rate;
        }
        public int QuoteID => _quote.Id;
        public int RateIndex => _quote.Rates.IndexOf(_rate);
        public int RateID => _rate.Id;
        public string AccommodationType => _rate.AccommodationType;
        public Decimal Price => _rate.Price;
    }
