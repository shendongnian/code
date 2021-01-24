    [JsonConverter(typeof(AmountConverter))]
    public class Amount : IConvertible
    {
        private double _val = 0;
        private int _decimal = 5;
        public double Value { get { return _val; } }
        public Amount()
        {
        }
        public Amount(double amount)
            : this()
        {
            // this.Value = amount;
            _val = Math.Round(amount, _decimal);
        }
        #region IConvertible Members
        #endregion
    }
