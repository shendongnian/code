public override void PostInitialize()
        {
            var externalAuthConfiguration = IocManager.Resolve<IExternalAuthConfiguration>();
            externalAuthConfiguration.Providers.Add(
                 new ExternalLoginProviderInfo(
                    FacebookAuthProvider.Name,
                    configuration["Authentication:Facebook:ClientId"],
                    configuration["Authentication:Facebook:Secret"],
                    typeof(FacebookAuthProvider)
                )
            );           
        }
*FacebookAuthProvider.cs
public class FacebookAuthProvider: ExternalAuthProviderApiBase
    {
        private static readonly HttpClient Client = new HttpClient();
        public const string Name = "Facebook";
        public override async Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            //gen app access token
            var appAccessTokenResponse = await Client.GetStringAsync("https://graph.facebook.com/oauth/access_token" +
              "?client_id=" + ProviderInfo.ClientId +
              "&client_secret=" + ProviderInfo.ClientSecret +
              "&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            //validate user access token
            var userAccessTokenValidationResponse = await Client.GetStringAsync("https://graph.facebook.com/v3.2/debug_token" +
                "?input_token="+ accessCode +
                "&access_token="+ appAccessToken.AccessToken);
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);
            if (!userAccessTokenValidation.Data.IsValid)
            {
                throw new ArgumentException("login_failure Invalid facebook token.");
            }
            //get userinfo
            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v3.2/me?fields=id,email,first_name,last_name&access_token={accessCode}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);
            return new ExternalAuthUserInfo
            {
                Name = userInfo.FirstName,
                EmailAddress = userInfo.Email,
                Surname=userInfo.LastName,
                Provider=Name,
                ProviderKey=userInfo.Id.ToString()
            };
        }
    }
Models 
internal class FacebookUserData
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public FacebookPictureData Picture { get; set; }
    }
    internal class FacebookPictureData
    {
        public FacebookPicture Data { get; set; }
    }
    internal class FacebookPicture
    {
        public int Height { get; set; }
        public int Width { get; set; }
        [JsonProperty("is_silhouette")]
        public bool IsSilhouette { get; set; }
        public string Url { get; set; }
    }
    internal class FacebookUserAccessTokenData
    {
        [JsonProperty("app_id")]
        public long AppId { get; set; }
        public string Type { get; set; }
        public string Application { get; set; }
        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
    internal class FacebookUserAccessTokenValidation
    {
        public FacebookUserAccessTokenData Data { get; set; }
    }
    internal class FacebookAppAccessToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
