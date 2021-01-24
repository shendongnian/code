    public static async Task DoWorkLoads(NotificationsInput notificationsInput)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
       var block = new ActionBlock<Something>(MyMethodAsync, options);
    
       foreach (var notification in notificationsInput.Notifications)
          block.Post(notification);
    
       block.Complete();
       await block.Completion;
    
    }
    ...
    public async Task MyMethodAsync(Notification notification)
    {       
         var result = await CreateNotification(notification);
         notification.Result = result;    
    }
