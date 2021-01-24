    using System;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.DataFactory;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace GetDataFactory
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                // Set variables
                string tenantID = "<your tenant ID>";
                string applicationId = "<your application ID>";
                string authenticationKey = "<your authentication key for the application>";
                string subscriptionId = "<your subscription ID where the data factory resides>";
                string resourceGroup = "<your resource group where the data factory resides>";
                string dataFactoryName = "<specify the name of data factory to create. It must be globally unique.>";
    
                // Authenticate and create a data factory management client
                var context = new AuthenticationContext("https://login.windows.net/" + tenantID);
                ClientCredential cc = new ClientCredential(applicationId, authenticationKey);
                AuthenticationResult result = context.AcquireTokenAsync("https://management.azure.com/", cc).Result;
                ServiceClientCredentials cred = new TokenCredentials(result.AccessToken);
                var client = new DataFactoryManagementClient(cred) { SubscriptionId = subscriptionId };
    
                var myFactory = client.Factories.Get(resourceGroup, dataFactoryName);
    
                //Getting principal Id as you mentioned in question, but you can get more information from the Identity object as per your need.
                Guid? principalId = myFactory.Identity.PrincipalId;
            }
        }
    }
