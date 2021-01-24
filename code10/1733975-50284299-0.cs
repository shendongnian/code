     public EventBusServiceBus(IServiceBusPersisterConnection serviceBusPersisterConnection,
            ILogger<EventBusServiceBus> logger, IEventBusSubscriptionsManager subsManager, string subscriptionClientName,
            ILifetimeScope autofac, AzureUserCredentials userCredentials, string subscriptionId, string resourceGroupName, string serviceBusName, string topicName)
        {
            _serviceBusPersisterConnection = serviceBusPersisterConnection;
            _logger = logger;
            _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
            _subscriptionClient = new Microsoft.Azure.ServiceBus.SubscriptionClient(serviceBusPersisterConnection.ServiceBusConnectionStringBuilder,
                subscriptionClientName);
            _autofac = autofac;
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(
              userCredentials.ClientId, userCredentials.ClientSecret, userCredentials.TenantId, AzureEnvironment.FromName(userCredentials.EnvironmentName));
                       
            var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithSubscription(subscriptionId);
            var nm = azure.ServiceBusNamespaces.GetByResourceGroup(resourceGroupName, serviceBusName);
            var topic = nm.Topics.GetByName(topicName);
            if (topic == null)
                throw new ArgumentException($"Topic {topic} does not exist.", nameof(topic));
            Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription subscription = null;
            try
            { subscription = topic.Subscriptions.GetByName(subscriptionClientName); }
            catch { }
            if (subscription == null)
            {
                logger.LogInformation($"Creating Azure Subscription '{subscriptionClientName}'");
                topic.Subscriptions.Define(subscriptionClientName).WithDeleteOnIdleDurationInMinutes(5).Create();
            }
            else
            {
                logger.LogInformation($"Azure Subscription '{subscriptionClientName}' already exists. Reusing.");
            }
            RemoveDefaultRule();
            RegisterSubscriptionClientMessageHandler();
        }
