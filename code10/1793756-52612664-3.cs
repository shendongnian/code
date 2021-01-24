    using System;
    using System.Threading.Tasks;
    using Flurl;
    using Flurl.Http;
    
    namespace MyApp.Services {
    
        public class IpAddress {
            public string Ip { get; set; }
        }
    
        public partial class ApiService {
    
            public static async Task<IpAddress> GetStringAsync() {
                return await "https://api.ipify.org".SetQueryParam( "format", "json" ).GetJsonAsync<IpAddress>();
            }
    
            public static async Task CallGetStringAsync() {
                var returned = await GetStringAsync();
                Console.Write( returned );
            }
    
        }
    }
