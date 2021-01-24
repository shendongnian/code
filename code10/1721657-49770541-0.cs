    var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"auth file path");
    var azure = Azure
               .Configure()
               .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
               .Authenticate(credentials)
               .WithDefaultSubscription();
    var sbNameSpace = "service bus namespace";
    var resoureGroup = "resource group";
    var servicebus = azure.ServiceBusNamespaces.GetByResourceGroup(resoureGroup, sbNameSpace);
    var queue = servicebus.Queues.Define("queuename").Create()
