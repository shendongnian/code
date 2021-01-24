     public class FooConfig
    {
        public string Host { get; set; }
        public string IntegratorKey { get; set; }
        public string UserId { get; set; }
        public string OAuthBasePath { get; set; }
        public string PrivateKeyFilename { get; set; }
        public int ExpiresInHours { get; set; }
        public ApiClient ApiClient { get; set; }
        public FooConfig()
        {
            this.UserId = "e1f43c1a-2546-4317-85a9-cea367f8f92c";
            this.OAuthBasePath = "account-d.docusign.com";
            this.IntegratorKey = "<integrator-key>";
            this.PrivateKeyFilename = @"C:\Users\me\privateKey.pem";
            this.ExpiresInHours = 1;
            this.Host = "https://demo.docusign.net/restapi";
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////
    FooConfig testConfig = new FooConfig();
    testConfig.ApiClient = new ApiClient(testConfig.Host);
    // If this is the first time logging in - Get Consent from the user - this is a onetime step.
    Uri oauthURI = testConfig.ApiClient.GetAuthorizationUri(testConfig.IntegratorKey, scopes, "https://docusign.com", OAuth.CODE, "testState");
    Process.Start(oauthURI.ToString());
    string key = File.ReadAllText(testConfig.PrivateKeyFilename);
    OAuth.OAuthToken tokenInfo = testConfig.ApiClient.ConfigureJwtAuthorizationFlowByKey(testConfig.IntegratorKey, testConfig.UserId, testConfig.OAuthBasePath, key, testConfig.ExpiresInHours);
