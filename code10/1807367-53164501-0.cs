    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    namespace ConsoleApp6
    {
      class Program
      {
        const string json = @"
    {
      ""address"": ""address"",
      ""id"": 1,
      ""latitude"": 46.0757062,
      ""longitude"": 18.1975697,
      ""name"": ""store name"",
      ""openingHours"":
        [
            { ""closeing"": ""01:00:00"", ""opening"": ""11:00:00"", ""weekday"": 1 }
        ]
    }
    ";
        static void Main( string[] args )
        {
          Pub rehydrated;
          try
          {
            rehydrated = JsonConvert.DeserializeObject<Pub>( json );
          }
          catch ( Exception e )
          {
            Console.WriteLine( e.ToString() );
          }
          return;
        }
        public class Pub
        {
          [JsonProperty( "id" )]
          public int Id { get; set; }
          [JsonProperty( "name" )]
          public string Name { get; set; }
          [JsonProperty( "latitude" )]
          public double Latitude { get; set; }
          [JsonProperty( "longitude" )]
          public double Longitude { get; set; }
          [JsonProperty( "openingHours" )]
          public List<OpeningHours> Openinghours { get; set; }
          public class OpeningHours
          {
            [JsonProperty( "weekday" )]
            public int Day { get; set; }
            [JsonProperty( "opening" )]
            public TimeSpan Open { get; set; }
            [JsonProperty( "closeing" )]
            public TimeSpan Close { get; set; }
          }
        }
      }
    }
