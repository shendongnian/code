    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using System;
    
    namespace ConsoleApp11
    {
        class Program
        {
            static void Main(string[] args)
            {
                //assume you know the message id
                string message_id = "3798f6b6-1541-4421-b8de-79a8294edf49";
    
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
                // Create the queue client.
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
    
                // Retrieve a reference to a container.
                CloudQueue queue = queueClient.GetQueueReference("myqueue0905");
    
                //Retrieve the cached approximate message count.
                queue.FetchAttributes();
                int? cachedMessageCount = queue.ApproximateMessageCount;
    
                //if the queue is not null
                if (cachedMessageCount != null)
                {
    
                    foreach (CloudQueueMessage message in queue.GetMessages(cachedMessageCount.Value))
                    {
                        if (message.Id == message_id)
                        {
                            message.SetMessageContent("test updated content again");
                            queue.UpdateMessage(message, TimeSpan.FromSeconds(5.0),
                                MessageUpdateFields.Content | MessageUpdateFields.Visibility);
                        }
                    }
    
                }
    
                Console.ReadLine();
            }
    
        }
    }
