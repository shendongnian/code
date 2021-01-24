    namespace Flighting
    {
        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class Flight
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }
    
            [JsonProperty("results")]
            public List<Result> Results { get; set; }
        }
    
        public partial class Result
        {
            [JsonProperty("itineraries")]
            public List<Itinerary> Itineraries { get; set; }
    
            [JsonProperty("fare")]
            public Fare Fare { get; set; }
        }
    
        public partial class Fare
        {
            [JsonProperty("total_price")]
            public string TotalPrice { get; set; }
    
            [JsonProperty("price_per_adult")]
            public PricePerAdult PricePerAdult { get; set; }
    
            [JsonProperty("restrictions")]
            public Restrictions Restrictions { get; set; }
        }
    
        public partial class PricePerAdult
        {
            [JsonProperty("total_fare")]
            public string TotalFare { get; set; }
    
            [JsonProperty("tax")]
            public string Tax { get; set; }
        }
    
        public partial class Restrictions
        {
            [JsonProperty("refundable")]
            public bool Refundable { get; set; }
    
            [JsonProperty("change_penalties")]
            public bool ChangePenalties { get; set; }
        }
    
        public partial class Itinerary
        {
            [JsonProperty("outbound")]
            public Outbound Outbound { get; set; }
    
            [JsonProperty("inbound")]
            public Inbound Inbound { get; set; }
        }
    
        public partial class Inbound
        {
            [JsonProperty("flights")]
            public List<InboundFlight> Flights { get; set; }
        }
    
        public partial class InboundFlight
        {
            [JsonProperty("departs_at")]
            public string DepartsAt { get; set; }
    
            [JsonProperty("arrives_at")]
            public string ArrivesAt { get; set; }
    
            [JsonProperty("origin")]
            public Origin Origin { get; set; }
    
            [JsonProperty("destination")]
            public Destination Destination { get; set; }
    
            [JsonProperty("marketing_airline")]
            public string MarketingAirline { get; set; }
    
            [JsonProperty("operating_airline")]
            public string OperatingAirline { get; set; }
    
            [JsonProperty("flight_number")]
            public string FlightNumber { get; set; }
    
            [JsonProperty("aircraft")]
            public string Aircraft { get; set; }
    
            [JsonProperty("booking_info")]
            public BookingInfo BookingInfo { get; set; }
        }
    
        public partial class BookingInfo
        {
            [JsonProperty("travel_class")]
            public string TravelClass { get; set; }
    
            [JsonProperty("booking_code")]
            public string BookingCode { get; set; }
    
            [JsonProperty("seats_remaining")]
            public long SeatsRemaining { get; set; }
        }
    
        public partial class Destination
        {
            [JsonProperty("airport")]
            public string Airport { get; set; }
        }
    
        public partial class Origin
        {
            [JsonProperty("airport")]
            public string Airport { get; set; }
    
            [JsonProperty("terminal")]
            public string Terminal { get; set; }
        }
    
        public partial class Outbound
        {
            [JsonProperty("flights")]
            public List<OutboundFlight> Flights { get; set; }
        }
    
        public partial class OutboundFlight
        {
            [JsonProperty("departs_at")]
            public string DepartsAt { get; set; }
    
            [JsonProperty("arrives_at")]
            public string ArrivesAt { get; set; }
    
            [JsonProperty("origin")]
            public Destination Origin { get; set; }
    
            [JsonProperty("destination")]
            public Origin Destination { get; set; }
    
            [JsonProperty("marketing_airline")]
            public string MarketingAirline { get; set; }
    
            [JsonProperty("operating_airline")]
            public string OperatingAirline { get; set; }
    
            [JsonProperty("flight_number")]
            public string FlightNumber { get; set; }
    
            [JsonProperty("aircraft")]
            public string Aircraft { get; set; }
    
            [JsonProperty("booking_info")]
            public BookingInfo BookingInfo { get; set; }
        }
    
        public partial class Flight
        {
            public static Flight FromJson(string json) => JsonConvert.DeserializeObject<Flight>(json, Flighting.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Flight self) => JsonConvert.SerializeObject(self, Flighting.Converter.Settings);
        }
    
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
