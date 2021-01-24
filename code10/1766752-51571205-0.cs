    // Summary:
    //     Gets the type of the token.
    [JsonProperty(PropertyName = "token_type")]  //<---
    public string TokenType { get; set; }
    //
    // Summary:
    //     Gets the refresh token.
    [JsonProperty(PropertyName = "token_type")] //<---
    public string RefreshToken { get; set; }
