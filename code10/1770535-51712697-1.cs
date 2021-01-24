            ApiClient apiClient = new ApiClient(host);
            OAuth.OAuthToken tokenInfo = apiClient.ConfigureJwtAuthorizationFlowByKey(integratorKey, userId, oauthBasePath, privateKey, expiresInHours);
            OAuth.UserInfo userInfo = apiClient.GetUserInfo(tokenInfo.access_token);
            foreach (var item in userInfo.GetAccounts())
            {
                if (item.GetIsDefault() == "true")
                {
                    accountId = item.AccountId();
                    apiClient = new ApiClient(item.GetBaseUri() + "/restapi");
                    break;
                }
            }
            EnvelopesApi envelopesApi = new EnvelopesApi(apiClient.Configuration);
