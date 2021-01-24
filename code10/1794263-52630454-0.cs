    using Microsoft.Azure.Management.ResourceManager;
    ...
    var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
    var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
    var secret = Environment.GetEnvironmentVariable("AZURE_SECRET");
    var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
    // Build the service credentials and Azure Resource Manager clients
    var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, secret);
    var resourceClient = new ResourceManagementClient(serviceCreds);
    resourceClient.SubscriptionId = subscriptionId;
    // Getting the resource groups
    var groups=resourceClient.ResourceGroups.List().ToList();
