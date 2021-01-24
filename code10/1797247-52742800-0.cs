    var topicName = "yourTopicName";
    var serviceBusConnectionString = "yourServiceBusManageRule";
    var nameSpaceMgr = NamespaceManager.CreateFromConnectionString(serviceBusConnectionString);
    var messagingFactory = MessagingFactory.CreateFromConnectionString(serviceBusConnectionString);
    var tenants = new List<string>{ "Tenant1", "Tenant2" };
    
    foreach (var tenant in tenants)
    {
    	var subscriptionClient = messagingFactory.CreateSubscriptionClient(topicName, tenant);
    	var subscriberFilter = new SqlFilter($"Tenant = '{tenant}'");
    	var subscriberRuleName = "TenantRule";
    	var subscriberRule = new RuleDescription(subscriberRuleName, subscriberFilter);
    
    	var defaultRule = "$Default";
    	if (nameSpaceMgr.GetRules(topicName, tenant).Any(r=> r.Name == defaultRule))
    	{
    		subscriptionClient.RemoveRule(defaultRule);
    	}
    
    	if (nameSpaceMgr.GetRules(topicName, tenant).Any(r => r.Name == subscriberRuleName))
    	{
    		subscriptionClient.RemoveRule(subscriberRuleName);
    	}
    	subscriptionClient.AddRule(subscriberRule);
    }
