     _graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async requestMessage =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                }));
    Dictionary<string, object> addData = new Dictionary<string, object>
                    {
                        {"Key","Value" }
                    };
                    var extObject = new OpenTypeExtension();
                    extObject.ExtensionName = "TestExtension";
                    extObject.AdditionalData = addData;
                    try
                    {
                        await _graphClient.Users["usernamegoeshere"].Extensions.Request().AddAsync(extObject);
                    }
