    var cs = azureServiceBusConnectionString;
    var namespaceManager = NamespaceManager.CreateFromConnectionString(cs);
    if (namespaceManager.QueueExists(queueName))
    {
    	namespaceManager.DeleteQueue(queueName);
    }
    
    var queueDescription = new QueueDescription(queueName);
    queueDescription.EnablePartitioning = true;
    
    var que = namespaceManager.CreateQueue(queueDescription);
