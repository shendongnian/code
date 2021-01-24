     //auth file:c:\tom\azureCredential.txt
     var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"c:\tom\azureCredential.txt"); 
     var azure = Azure
                 .Configure()
                 .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                 .Authenticate(credentials)
                 .WithDefaultSubscription();
     var serviceBus = azure.ServiceBusNamespaces.GetByResourceGroup("Resource group name", "servicebus namespace");
     var queue = serviceBus.Queues.GetByName("queueName");
     var activeMessageCount = queue.ActiveMessageCount;
     var deadletterCount = queue.DeadLetterMessageCount;
