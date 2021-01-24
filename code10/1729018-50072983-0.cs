    internal class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonIgnore]
        public TokenUser UserToken { get; set; }
    }
    
    
    
    internal class TokenUser
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }
    
        [JsonProperty("Email")]
        public string Email { get; set; }
    
        [JsonProperty("ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }
    
        [JsonProperty("UserName")]
        public string UserName { get; set; }
    
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
    
        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }
    
    
    tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jsonTokenResponse);
    tokenResponse.UserToken = JsonConvert.DeserializeObject<TokenUser>(tokenResponse);
