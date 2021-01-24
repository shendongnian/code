        public static async Task Run(
            [QueueTrigger("domain-verificate-Office365-add-services-get-mx-record")]string myQueueItem, ILogger log,
            [Queue("domain-add-mx-record-to-registrator", Connection = "StorageConnectionString")]IAsyncCollector<string> outputQueue,
            [Queue("domain-verificate-Office365-add-services-get-mx-record", Connection = "StorageConnectionString")]CloudQueue listenQueue
        )
        {
            
            try 
            {
                // do stuff then output message
                await outputQueue.AddAsync(myQueueItem);
            }
            catch(DomainVerificationRecordNotFoundException)
            {
                // add the message in current queue and can only be visible after 5 minutes
                await listenQueue.AddMessageAsync(new CloudQueueMessage(myQueueItem), null, TimeSpan.FromMinutes(5), null, null);
            }
        }
