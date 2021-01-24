    var cs = azureServiceBusConnectionString;
    var namespaceManager = NamespaceManager.CreateFromConnectionString(cs);
    if (namespaceManager.QueueExists(queueName))
    {
    	namespaceManager.DeleteQueue(queueName);
    }
    
    var queueDescription = new QueueDescription(queueName);
    queueDescription.EnablePartitioning = true;
    queueDescription.MaxSizeInMegabytes = 1024;
    
    var que = namespaceManager.CreateQueue(queueDescription);
