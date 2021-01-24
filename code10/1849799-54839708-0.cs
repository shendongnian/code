    using Newtonsoft.Json;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        static class Program
        {
            static async Task Main( string[] args )
            {
                var endpoint = new RoomEndpoint( new FakeJsonProvider() );
                var response = await endpoint.GetFooAsync();
                var mydata = response.Data
                    .Where( e => e.Value.CheapestRoom?.Corp?.Price != null )
                    .Select( e => new { e.Key, Price = e.Value.CheapestRoom.Corp.Price.Value, Type = e.Value.CheapestRoom.Corp.Type } )
                    .ToList();
    
                foreach (var item in mydata)
                {
                    Console.WriteLine( "{0}-{1}: {2}", item.Key, item.Type, item.Price );
                }
            }
        }
    
        interface IJsonProvider
        {
            Task<string> GetAsync( string uri );
        }
    
        class RoomEndpoint
        {
            private readonly IJsonProvider _jsonProvider;
    
            public RoomEndpoint( IJsonProvider jsonProvider )
            {
                _jsonProvider = jsonProvider ?? throw new ArgumentNullException( nameof( jsonProvider ) );
            }
            public async Task<FooResponseData> GetFooAsync()
            {
                var json = await _jsonProvider.GetAsync( "foo" ).ConfigureAwait( false );
                return JsonConvert.DeserializeObject<FooResponseData>( json );
            }
        }
    
        class FakeJsonProvider : IJsonProvider
        {
            public Task<string> GetAsync( string uri )
            {
                string json = null;
                switch (uri)
                {
                    case "foo":
                        json = json = Properties.Resources.FooResponseJson; // contains the given Json Response
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                return Task.FromResult( json );
            }
        }
    
        class CorpData
        {
            [JsonProperty( "price" )]
            public decimal? Price { get; set; }
            [JsonProperty( "type" )]
            public string Type { get; set; }
        }
    
        class WebsiteData
        {
    
        }
    
        class RoomData
        {
            [JsonProperty( "corp" )]
            public CorpData Corp { get; set; }
            [JsonProperty( "website" )]
            public WebsiteData Website { get; set; }
        }
    
        class KeyData
        {
            [JsonProperty( "cheapest_room" )]
            public RoomData CheapestRoom { get; set; }
            [JsonProperty( "availibility" )]
            public int? Availability { get; set; }
            [JsonProperty( "tcr_multiplier" )]
            public int? TcrMultiplier { get; set; }
        }
    
        class FooResponseData
        {
            [JsonProperty( "status" )]
            public int Status { get; set; }
            [JsonProperty( "data" )]
            public IDictionary<string, KeyData> Data { get; set; }
        }
    }
