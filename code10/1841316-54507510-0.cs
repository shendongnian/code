    using Newtonsoft.Json;
    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "";//download json
    
                Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(json);
                
                DateTime tt = obj.Response.MetaInfo.Timestamp;
            }
        }    
    
        public class Rootobject
        {
            public Response Response { get; set; }
        }
    
        public class Response
        {
            public Metainfo MetaInfo { get; set; }
            public View[] View { get; set; }
        }
    
        public class Metainfo
        {
            public DateTime Timestamp { get; set; }
        }
    
        public class View
        {
            public string _type { get; set; }
            public int ViewId { get; set; }
            public Result[] Result { get; set; }
        }
    
        public class Result
        {
            public float Relevance { get; set; }
            public string MatchLevel { get; set; }
            public Matchquality MatchQuality { get; set; }
            public Location Location { get; set; }
        }
    
        public class Matchquality
        {
            public float PostalCode { get; set; }
        }
    
        public class Location
        {
            public string LocationId { get; set; }
            public string LocationType { get; set; }
            public Displayposition DisplayPosition { get; set; }
            public Navigationposition[] NavigationPosition { get; set; }
            public Mapview MapView { get; set; }
            public Address Address { get; set; }
        }
    
        public class Displayposition
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }
    
        public class Mapview
        {
            public Topleft TopLeft { get; set; }
            public Bottomright BottomRight { get; set; }
        }
    
        public class Topleft
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }
    
        public class Bottomright
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }
    
        public class Address
        {
            public string Label { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string County { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public Additionaldata[] AdditionalData { get; set; }
        }
    
        public class Additionaldata
        {
            public string value { get; set; }
            public string key { get; set; }
        }
    
        public class Navigationposition
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }
    }
