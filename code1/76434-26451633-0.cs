    using System.Threading.Tasks;
    using AsyncOAuth;
    using System.Net.Http;
    using System.Security.Cryptography;
    public class TwitterClient
    {
        private readonly HttpClient _httpClient;
        public TwitterClient()
        {
            // See AsyncOAuth docs (differs for WinRT)
            OAuthUtility.ComputeHash = (key, buffer) =>
            {
                using (var hmac = new HMACSHA1(key))
                {
                    return hmac.ComputeHash(buffer);
                }
            };
            // Best to store secrets outside app (Azure Portal/etc.)
            _httpClient = OAuthUtility.CreateOAuthClient(
                AppSettings.TwitterAppId, AppSettings.TwitterAppSecret,
                new AccessToken(AppSettings.TwitterAccessTokenKey, AppSettings.TwitterAccessTokenSecret));
        }
        public async Task UpdateStatus(string status)
        {
            try
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"status", status}
                });
                var response = await _httpClient.PostAsync("https://api.twitter.com/1.1/statuses/update.json", content);
                if (response.IsSuccessStatusCode)
                {
                    // OK
                }
                else
                {
                    // Not OK
                }
            }
            catch (Exception ex)
            {
                // Log ex
            }
        }
    }
