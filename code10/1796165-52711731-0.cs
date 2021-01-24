    #r "..\\bin\\Microsoft.Azure.ServiceBus.dll"
    #r "..\\bin\\Microsoft.Azure.Devices.Shared.dll"
    #r "Microsoft.Azure.WebJobs.ServiceBus"
    #r "Newtonsoft.Json"
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.Azure.WebJobs.ServiceBus;
    using Microsoft.Azure.ServiceBus;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Web;
    using Microsoft.Azure.Devices.Shared;
    // reusable proxy
    static HttpClientHelper iothub = new HttpClientHelper(Environment.GetEnvironmentVariable("AzureIoTHubShariedAccessPolicy"));
    public static async Task Run(Message queueItem, ILogger log)
    {
        // payload
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {Encoding.UTF8.GetString(queueItem.Body)}");
    
        // device identity Id
        var deviceId = queueItem.UserProperties["iothub-connection-device-id"];
    
        // get the device twin
        var response = await iothub.Client.GetAsync($"/twins/{deviceId}?api-version=2018-06-30");
        response.EnsureSuccessStatusCode();
        Twin twin = await response.Content.ReadAsAsync<Twin>();
        log.LogInformation(JsonConvert.SerializeObject(twin.Tags, Formatting.Indented));
        await Task.CompletedTask;
    }
    // helpers
    class HttpClientHelper
    {
        HttpClient client;
        DateTime expiringSaS;
        (string hostname, string keyname, string key) config;
        public HttpClientHelper(string connectionString)
        {
            config = GetPartsFromConnectionString(connectionString);
            client = new HttpClient() { BaseAddress = new Uri($"https://{config.hostname}")};
            SetAuthorizationHeader();         
        }
        public HttpClient Client
        {
            get
            {          
                if (expiringSaS < DateTime.UtcNow.AddMinutes(-1))
                {
                   SetAuthorizationHeader();  
                }         
                return client;
            }
        }
        internal void SetAuthorizationHeader()
        {
            lock (client)
            {
                if (expiringSaS < DateTime.UtcNow.AddMinutes(-1)) 
                {
                    string sasToken = GetSASToken(config.hostname, config.key, config.keyname, 1);
                    if (client.DefaultRequestHeaders.Contains("Authorization"))
                        client.DefaultRequestHeaders.Remove("Authorization");
                    client.DefaultRequestHeaders.Add("Authorization", sasToken);
                    expiringSaS = DateTime.UtcNow.AddHours(1);
                }
            }
        }
        internal (string hostname, string keyname, string key) GetPartsFromConnectionString(string connectionString)
        {
            var parts = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(new[] { '=' }, 2)).ToDictionary(x => x[0].Trim(), x => x[1].Trim());
            return (parts["HostName"] ?? "", parts["SharedAccessKeyName"] ?? "", parts["SharedAccessKey"] ?? "");
        }
        internal string GetSASToken(string resourceUri, string key, string keyName = null, uint hours = 24)
        {
            var expiry = GetExpiry(hours);
            string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(key));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, $"SharedAccessSignature sr={HttpUtility.UrlEncode(resourceUri)}&sig={HttpUtility.UrlEncode(signature)}&se={expiry}");
            if (!string.IsNullOrEmpty(keyName))
                sasToken += $"&skn={keyName}";
            return sasToken;
        }
        internal string GetExpiry(uint hours = 24)
        {
            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToString((int)sinceEpoch.TotalSeconds + 3600 * hours);
        }
    }
