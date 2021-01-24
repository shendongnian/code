    public const string BaseUri = "https://example.sharepoint.com";
    private static HttpClient _client;
    public static void Initialize()
    {
        SharePointOnlineCredentials currentCredentials = GetCredentialsHere();
        var handler = new HttpClientHandler
        {
            Credentials = currentCredentials
        };
        _client = new HttpClient(handler);
        // you are missing this line
        handler.CookieContainer.SetCookies(BaseUri, currentCredentials.GetAuthenticationCookie(BaseUri));
        _client.BaseAddress = BaseUri;
        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.MaxResponseContentBufferSize = 2147483647;
    }
