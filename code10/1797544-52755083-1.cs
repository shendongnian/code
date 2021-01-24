    public class Configuration
    {
        [JsonProperty("applicationConfig")]
        ApplicationConfig ApplicationConfig { get; set; }
    
        [JsonProperty("pathConfig")]
        PathConfig PathConfig { get; set; }
    
        [JsonProperty("credentialConfig")]
        CredentialConfig CredentialConfig { get; set; }
    }
    // Other classes as before, although preferably with the password property more conventionally named
