    var builder = new HostBuilder()
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                    .AddAzureStorage()
                    .AddEventHubs(eventHubOptions => {
                        var hubName = "hubName";
                        var iotHubConnectionString = "iotHubConnectionString";
                        var storageContainerName = "storageContainerName";
                        var storageConnectionString = "storageConnectionString";
                        var consumerGroupName = "consumerGroupName";
                        var processorHost = new EventProcessorHost(hubName, consumerGroupName, iotHubConnectionString, storageConnectionString, storageContainerName);
                        eventHubOptions.AddEventProcessorHost("eventHubName", processorHost);
                    })
