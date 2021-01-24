    var tasks = notificationsInput.Notifications.Select(async (notification) =>
    {
        try
        {
            var result = await CreateNotification(notification);
            notification.Result = result;          
        }
        catch (Exception exception)
        {
            notification.Result = null;
        }
    });
    await Task.WhenAll(tasks);
