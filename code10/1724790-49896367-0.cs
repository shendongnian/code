    public class Flight
    {
        public string flightNumber { get; set; }
        public Seat seatjson { get; set; }
    }
    
    public class Seat
    {
        public decimal? totalBasePrice { get; set; }
        public decimal? totalPrice { get; set; }
        public decimal? totalTax { get; set; }
        public string currency { get; set; }
        public string validatingCarrier { get; set; }
        public DateTime? lastTicketingDate { get; set; }
        public string fareOptions { get; set; }
        public string recordLocator { get; set; }
    }
 
