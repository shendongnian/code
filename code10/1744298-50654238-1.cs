    public class Origin
    {
        public string airport { get; set; }
    }
    public class Destination
    {
        public string airport { get; set; }
        public string terminal { get; set; }
    }
    public class BookingInfo
    {
        public string travel_class { get; set; }
        public string booking_code { get; set; }
        public int seats_remaining { get; set; }
    }
    public class Flight
    {
        public string departs_at { get; set; }
        public string arrives_at { get; set; }
        public Origin origin { get; set; }
        public Destination destination { get; set; }
        public string marketing_airline { get; set; }
        public string operating_airline { get; set; }
        public string flight_number { get; set; }
        public string aircraft { get; set; }
        public BookingInfo booking_info { get; set; }
    }
    public class Outbound
    {
        public List<Flight> flights { get; set; }
    }
    public class Origin2
    {
        public string airport { get; set; }
        public string terminal { get; set; }
    }
    public class Destination2
    {
        public string airport { get; set; }
    }
    public class BookingInfo2
    {
        public string travel_class { get; set; }
        public string booking_code { get; set; }
        public int seats_remaining { get; set; }
    }
    public class Flight2
    {
        public string departs_at { get; set; }
        public string arrives_at { get; set; }
        public Origin2 origin { get; set; }
        public Destination2 destination { get; set; }
        public string marketing_airline { get; set; }
        public string operating_airline { get; set; }
        public string flight_number { get; set; }
        public string aircraft { get; set; }
        public BookingInfo2 booking_info { get; set; }
    }
    public class Inbound
    {
        public List<Flight2> flights { get; set; }
    }
    public class Itinerary
    {
        public Outbound outbound { get; set; }
        public Inbound inbound { get; set; }
    }
    public class PricePerAdult
    {
        public string total_fare { get; set; }
        public string tax { get; set; }
    }
    public class Restrictions
    {
        public bool refundable { get; set; }
        public bool change_penalties { get; set; }
    }
    public class Fare
    {
        public string total_price { get; set; }
        public PricePerAdult price_per_adult { get; set; }
        public Restrictions restrictions { get; set; }
    }
    public class Result
    {
        public List<Itinerary> itineraries { get; set; }
        public Fare fare { get; set; }
    }
    public class RootObject
    {
        public string currency { get; set; }
        public List<Result> results { get; set; }
    }
