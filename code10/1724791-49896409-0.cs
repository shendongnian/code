    public class Seatjson
    {
        public object totalBasePrice { get; set; }
        public object totalPrice { get; set; }
        public object totalTax { get; set; }
        public object currency { get; set; }
        public object validatingCarrier { get; set; }
        public object lastTicketingDate { get; set; }
        public object fareOptions { get; set; }
        public object recordLocator { get; set; }
    }
    
    public class RootObject
    {
        public string flightNumber { get; set; }
        public Seatjson seatjson { get; set; }
    }
