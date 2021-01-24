            static void Main(string[] args)
            {
                        
               CloudStorageAccount storageAccount = CloudStorageAccount.Parse(                
                         CloudConfigurationManager.GetSetting("StorageConnectionString"));
            
               // Create the queue client.
               CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            
               // Retrieve a reference to a container.
               CloudQueue queue = queueClient.GetQueueReference("myqueue0905");
            
               //Retrieve the cached approximate message count.
               queue.FetchAttributes();
               int? cachedMessageCount = queue.ApproximateMessageCount;
            
               //get the message id and PopReceipt, or you can pass them from your api call.
               string _id = "";
               string _popreceipt = "";
            
               if (cachedMessageCount != null)
               {
            
                foreach (CloudQueueMessage message in queue.GetMessages(cachedMessageCount.Value, TimeSpan.FromMinutes(3)))
                {
                     _id = message.Id;
                     _popreceipt = message.PopReceipt;
            
                     Console.WriteLine("the id is:" + _id);
                     Console.WriteLine("the pop receipt is:" + _popreceipt);
                               
                 }
            
                }
            
              //update queue message by using message id and PopReceipt
              var msg = new CloudQueueMessage(_id, _popreceipt);
              msg.SetMessageContent("a test messge 123456");
              queue.UpdateMessage(msg, TimeSpan.FromSeconds(120.0),
                                MessageUpdateFields.Content | MessageUpdateFields.Visibility);            
            
              Console.WriteLine("complete update");
              Console.ReadLine();
           }
