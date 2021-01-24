    class FlightInfo
    {
        public FlightInfo(string flightNumber, string origination, ...)
        {
            FlightNumber = flightNumber;
            Origination = origination;
            // ...
        }
        public string FlightNumber { get; set; }
        public string Origination { get; set; }
        public string Destination { get; set; }
        public string TakeoffTime { get; set; }
        public string LandingTime { get; set; }
        public int UserCount { get; set; }
    }
