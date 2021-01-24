     public partial class Configuration
    {
        [JsonProperty("applicationConfig")]
        public ApplicationConfig ApplicationConfig { get; set; }
        [JsonProperty("pathConfig")]
        public PathConfig PathConfig { get; set; }
        [JsonProperty("credentialConfig")]
        public CredentialConfig CredentialConfig { get; set; }
    }
    public partial class ApplicationConfig
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Site")]
        public string Site { get; set; }
    }
    public partial class CredentialConfig
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    public partial class PathConfig
    {
        [JsonProperty("SourcePath")]
        public string SourcePath { get; set; }
        [JsonProperty("TargetPath")]
        public string TargetPath { get; set; }
    }
