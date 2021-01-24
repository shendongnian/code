    public class CardDetails
    {
        public string cardholderName { get; set; }
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string securityCode { get; set; }
    }
    
    public class RootObject
    {
        public CardDetails cardDetails { get; set; }
    }
