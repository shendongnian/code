	var notifications = new ConcurrentBag<Notification>();
	var tasks = new List<Task>();
	foreach (var notification in notificationsInput.Notifications)
	{
		var task = CreateNotification(notification)
						.ContinueWith(t =>
						{
							if (t.Exception != null)
							{
								notification.Result = null;
							}
							else
							{
								notification.Result = t.Result;
							}
							notifications.Add(notification);
						});
		tasks.Add(task);
	}
	await Task.WhenAll(tasks);
