    #r "Newtonsoft.Json"
    
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    static string resourceUrl = "https://analysis.windows.net/powerbi/api";
    static string clientId = Environment.GetEnvironmentVariable("PBIE_CLIENT_ID");
    static string username = Environment.GetEnvironmentVariable("PBIE_USERNAME");
    static string password = Environment.GetEnvironmentVariable("PBIE_PASSWORD");
    static string groupId = Environment.GetEnvironmentVariable("PBIE_GROUP_ID");
    static string reportId = Environment.GetEnvironmentVariable("PBIE_REPORT_ID");
    static string tenantId = Environment.GetEnvironmentVariable("PBIE_TENANT_ID");
    static string tokenEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/token";
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ILogger log)
    {
        // Get access token 
        HttpClient authclient = new HttpClient();
    
        log.LogInformation(resourceUrl);
        log.LogInformation(tokenEndpoint);
    
        var authContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("resource", resourceUrl)
        });
    
        var accessToken = await authclient.PostAsync(tokenEndpoint, authContent).ContinueWith<string>((response) =>
        {
            log.LogInformation(response.Result.StatusCode.ToString());
            log.LogInformation(response.Result.ReasonPhrase.ToString());
            log.LogInformation(response.Result.Content.ReadAsStringAsync().Result);
            AzureAdTokenResponse tokenRes =
                JsonConvert.DeserializeObject<AzureAdTokenResponse>(response.Result.Content.ReadAsStringAsync().Result);
            return tokenRes?.AccessToken;
        });
    
        // Get PowerBi report url and embed token
        HttpClient powerBiClient = new HttpClient();
        powerBiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
    
        log.LogInformation(accessToken);
    
        var embedUrl =
            await powerBiClient.GetAsync($"https://api.powerbi.com/v1.0/myorg/groups/{groupId}/reports/{reportId}")
            .ContinueWith<string>((response) =>
            {
                log.LogInformation(response.Result.StatusCode.ToString());
                log.LogInformation(response.Result.ReasonPhrase.ToString());
                PowerBiReport report =
                    JsonConvert.DeserializeObject<PowerBiReport>(response.Result.Content.ReadAsStringAsync().Result);
                return report?.EmbedUrl;
            });
    
        var tokenContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("accessLevel", "view")
        });
    
        var embedToken = await powerBiClient.PostAsync($"https://api.powerbi.com/v1.0/myorg/groups/{groupId}/reports/{reportId}/GenerateToken", tokenContent)
            .ContinueWith<string>((response) =>
            {
                log.LogInformation(response.Result.StatusCode.ToString());
                log.LogInformation(response.Result.ReasonPhrase.ToString());
                PowerBiEmbedToken powerBiEmbedToken =
                    JsonConvert.DeserializeObject<PowerBiEmbedToken>(response.Result.Content.ReadAsStringAsync().Result);
                return powerBiEmbedToken?.Token;
            });
    
    
        // JSON Response
        EmbedContent data = new EmbedContent
        {
            EmbedToken = embedToken,
            EmbedUrl = embedUrl,
            ReportId = reportId
        };
        string jsonp = "callback(" + JsonConvert.SerializeObject(data) + ");";
    
        // Return Response
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(jsonp, Encoding.UTF8, "application/json")
        };
                
    }
    
    public class AzureAdTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
    
    public class PowerBiReport
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }
    
        [JsonProperty(PropertyName = "embedUrl")]
        public string EmbedUrl { get; set; }
    
        [JsonProperty(PropertyName = "datasetId")]
        public string DatasetId { get; set; }
    }
    
    public class PowerBiEmbedToken
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    
        [JsonProperty(PropertyName = "tokenId")]
        public string TokenId { get; set; }
    
        [JsonProperty(PropertyName = "expiration")]
        public DateTime? Expiration { get; set; }
    }
    
    public class EmbedContent
    {
        public string EmbedToken { get; set; }
        public string EmbedUrl { get; set; }
        public string ReportId { get; set; }
    }
