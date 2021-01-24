    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"auth file path");
    var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithDefaultSubscription();
    var account = azure.StorageAccounts.GetByResourceGroup(resoureGroup, accountName);
    var ipRange = account.IPAddressRangesWithAccess;
