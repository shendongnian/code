    GraphServiceClient graphServiceClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        string accessToken = await MsalAuthProvider.Instance.GetUserAccesstokenAsync();
                        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
                    }));
            return graphServiceClient;
