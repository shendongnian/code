    public class CustomerBO : IAddress
    {
        #region IAddress members
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        #endregion
        // ... lots of other properties here
    }
