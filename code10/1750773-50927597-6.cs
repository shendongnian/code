    public class AzureADB2CWithApiOptions : AzureADB2COptions
    {
        public string ApiScopes { get; set; }
        public string ApiUrl { get; set; }
        public string Authority => $"{Instance}/{Domain}/{DefaultPolicy}/v2.0";
        public string RedirectUri { get; set; }
    }
