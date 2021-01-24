     #install Microsoft.Azure.Management.ResourceManager.Fluent and Microsoft.Azure.Management.Fluent    
    string clientId = "client id";
         string secret = "secret key";
         string tenant = "tenant id";
         var functionName ="functionName";
         var webFunctionAppName = "functionApp name";
         string resourceGroup = "resource group name";
         var credentials = new AzureCredentials(new ServicePrincipalLoginInformation { ClientId = clientId, ClientSecret = secret}, tenant, AzureEnvironment.AzureGlobalCloud);
         var azure = Azure
                  .Configure()
                  .Authenticate(credentials)
                  .WithDefaultSubscription();
        
         var webFunctionApp = azure.AppServices.FunctionApps.GetByResourceGroup(resourceGroup, webFunctionAppName);
         var ftpUsername = webFunctionApp.GetPublishingProfile().FtpUsername;
         var username = ftpUsername.Split('\\').ToList()[1];
         var password = webFunctionApp.GetPublishingProfile().FtpPassword;
         var base64Auth = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
         var apiUrl = new Uri($"https://{webFunctionAppName}.scm.azurewebsites.net/api");
         var siteUrl = new Uri($"https://{webFunctionAppName}.azurewebsites.net");
         string JWT;
         using (var client = new HttpClient())
          {
             client.DefaultRequestHeaders.Add("Authorization", $"Basic {base64Auth}");
        
             var result = client.GetAsync($"{apiUrl}/functions/admin/token").Result;
             JWT = result.Content.ReadAsStringAsync().Result.Trim('"'); //get  JWT for call funtion key
           }
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT);
            var key = client.GetAsync($"{siteUrl}/admin/functions/{functionName}/keys").Result.Content.ReadAsStringAsync().Result;
          }
