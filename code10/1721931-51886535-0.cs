     class Program
        {
            private static string accessToken;
            private static async Task Main(string[] args)
            {
                await ClientCredentialsFlow();
            }
    
            protected static async Task ClientCredentialsFlow()
            {
                var body = new Model
                {
                    grant_type = "client_credentials",
                    client_id = "[client id]",
                    client_secret = "[client secret]",
                    audience = "[API Identifier]"
                };
                using (var client = new HttpClient())
                {
                    var content = JsonConvert.SerializeObject(body);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("https://[domain].auth0.com/oauth/token", stringContent);
                    var responseBody = await res.Content.ReadAsStringAsync();
                    var deserilizeBody = JsonConvert.DeserializeObject<AuthResponseModel>(responseBody);
                    accessToken = deserilizeBody.access_token;
                    Console.WriteLine(accessToken);
    
                }
            }
            
            internal class Model
            {
    
                public string grant_type { get; set; }
                public string client_id { get; set; }
                public string client_secret { get; set; }
                public string audience { get; set; }
            }
    
            internal class AuthResponseModel
            {
                public string access_token { get; set; }
                public string scopes { get; set; }
                public string expires_in { get; set; }
                public string token_type { get; set; }
            }
    
        }
    }
