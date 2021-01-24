    static class NotificationSender
    {
    	static ConcurrentQueue<NotificationDelivery> deliveryQueue = null;
    	static Task enqueueTask = null;
    	static Task[] dequeueTasks = null;
    
    	static ManualResetEvent enqueueSignal = null;
    	static ManualResetEvent dequeueSignal = null;
    
    	static System.Timers.Timer enqueueTimer = null;
    
    	public static void StartSending(CancellationToken token)
    	{
    		PushService.InitServices();
    
    		using (DSTeckWebPushNotificationsContext db = new DSTeckWebPushNotificationsContext())
    		{
    			NotificationDelivery[] queuedDeliveries = db.NotificationDeliveries
    						.Where(nd => nd.Status == NotificationDeliveryStatus.Queued)
    						.ToArray();
    
    			foreach (NotificationDelivery delivery in queuedDeliveries)
    			{
    				delivery.Status = NotificationDeliveryStatus.Pending;
    			}
    
    			db.SaveChanges();
    		}
    
    		enqueueSignal = new ManualResetEvent(true);
    		dequeueSignal = new ManualResetEvent(false);
    
    		enqueueTimer = new System.Timers.Timer();
    		enqueueTimer.Elapsed += EnqueueTimerCallback;
    		enqueueTimer.Interval = 5000;
    		enqueueTimer.AutoReset = false;
    		enqueueTimer.Stop();
    
    		enqueueTask = new Task(EnqueueTask, token, TaskCreationOptions.LongRunning);
    		enqueueTask.Start();
    
    		deliveryQueue = new ConcurrentQueue<NotificationDelivery>();
    
    		int dequeueTasksCount = 10;
    		dequeueTasks = new Task[dequeueTasksCount];
    		for (int i = 0; i < dequeueTasksCount; i++)
    		{
    			dequeueTasks[i] = new Task(DequeueTask, token, TaskCreationOptions.LongRunning);
    			dequeueTasks[i].Start();
    		}
    	}
    
    	public static void EnqueueTimerCallback(Object source, ElapsedEventArgs e)
    	{
    		enqueueSignal.Set();
    		enqueueTimer.Stop();
    	}
    
    	public static void EnqueueTask(object state)
    	{
    		CancellationToken token = (CancellationToken)state;
    
    		using (DSTeckWebPushNotificationsContext db = new DSTeckWebPushNotificationsContext())
    		{
    			while (!token.IsCancellationRequested)
    			{
    				if (enqueueSignal.WaitOne())
    				{
    					int toEnqueue = 100 - deliveryQueue.Count;
    
    					if (toEnqueue > 0)
    					{
    						// fetch some records from db to be enqueued
    						NotificationDelivery[] deliveries = db.NotificationDeliveries
    							.Include("Subscription")
    							.Include("Notification")
    							.Include("Notification.NotificationLanguages")
    							.Include("Notification.NotificationLanguages.Language")
    							.Where(nd => nd.Status == NotificationDeliveryStatus.Pending && DateTime.Now >= nd.StartSendingAt)
    							.OrderBy(nd => nd.StartSendingAt)
    							.Take(toEnqueue)
    							.ToArray();
    
    						foreach (NotificationDelivery delivery in deliveries)
    						{
    							delivery.Status = NotificationDeliveryStatus.Queued;
    							deliveryQueue.Enqueue(delivery);
    						}
    
    						if (deliveries.Length > 0)
    						{
    							// save Queued state, so not fetched again the next loop
    							db.SaveChanges();
    
    							// signal the DequeueTask
    							dequeueSignal.Set();
    						}
    						else
    						{
    							// no more notifications, wait 5 seconds before try fetching again
    							enqueueSignal.Reset();
    							enqueueTimer.Start();
    						}
    					}
    
    					// save any changes made by the DequeueTask
    					// an event may be used here to know if any changes made
    					db.SaveChanges();
    				}
    			}
    
    			Task.WaitAll(dequeueTasks);
    			db.SaveChanges();
    		}
    	}
    
    	public async static void DequeueTask(object state)
    	{
    		CancellationToken token = (CancellationToken)state;
    
    		while (!token.IsCancellationRequested)
    		{
    			if (dequeueSignal.WaitOne()) // block untill we have items in the queue
    			{
    				NotificationDelivery delivery = null;
    
    				if (deliveryQueue.TryDequeue(out delivery))
    				{
    					NotificationDeliveryStatus ns = NotificationDeliveryStatus.Pending;
    					if (delivery.Subscription.Status == SubscriptionStatus.Subscribed)
    					{
    						PushResult result = await PushService.DoPushAsync(delivery);
    
    						switch (result)
    						{
    							case PushResult.Pushed:
    								ns = NotificationDeliveryStatus.Delivered;
    								break;
    							case PushResult.Error:
    								ns = NotificationDeliveryStatus.FailureError;
    								break;
    							case PushResult.NotSupported:
    								ns = NotificationDeliveryStatus.FailureNotSupported;
    								break;
    							case PushResult.UnSubscribed:
    								ns = NotificationDeliveryStatus.FailureUnSubscribed;
    								delivery.Subscription.Status = SubscriptionStatus.UnSubscribed;
    								break;
    						}
    					}
    					else
    					{
    						ns = NotificationDeliveryStatus.FailureUnSubscribed;
    					}
    
    					delivery.Status = ns;
    					delivery.DeliveredAt = DateTime.Now;
    				}
    				else
    				{
    					// empty queue, no more items
    					// stop dequeueing untill new items added by EnqueueTask
    					dequeueSignal.Reset();
    				}
    			}
    		}
    	}
    
    	public static void Wait()
    	{
    		Task.WaitAll(enqueueTask);
    		Task.WaitAll(dequeueTasks);
    
    		enqueueTask.Dispose();
    		for(int i = 0; i < dequeueTasks.Length; i++)
    		{
    			dequeueTasks[i].Dispose();
    		}
    	}
    }
