    var appId = "ApplicationID";
    var secretKey = "SecretKey";
    var tenantId = "TenantID(aka DirectoryID)";
    var subscriptionId = "SubscriptionId";
    var resourceGroupName = "ResourceGroupName";
    var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
    ClientCredential clientCredential = new ClientCredential(appId, secretKey);
    var tokenResponse = context.AcquireTokenAsync("https://management.azure.com/", clientCredential).Result;
    var accessToken = tokenResponse.AccessToken;
    
    //OperationalInsights
    var opsClient = new OperationalInsightsManagementClient(new TokenCredentials(accessToken))
    {
         SubscriptionId = subscriptionId
    };
    var workspaces = opsClient.Workspaces.ListByResourceGroupAsync(resourceGroupName).Result;
    // Databricks
    using (var client = new HttpClient())
    {
         client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
         client.BaseAddress = new Uri("https://management.azure.com/");
         using (var response = await client.GetAsync(
                    $"subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Databricks/workspaces?api-version=2018-04-01"))
         {
              response.EnsureSuccessStatusCode();
              var content = await response.Content.ReadAsStringAsync();
              JObject json = JObject.Parse(content);
              Console.WriteLine(json);
         }
    }
