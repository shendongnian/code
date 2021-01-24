    // AppNotifier.cs
    public void ContactTransferred(long[] userIdList)
    {
        var notificationData = new Abp.Notifications.NotificationData();
    
        _notificationPublisher.Publish(
            AppNotificationNames.ContactTransferredAlert,
            notificationData,
            severity: NotificationSeverity.Info,
            userIds: userIdList
        );
    }
---
    // Usage
    
    private readonly IAppNotifier _appNotifier;
    
    var contactIdList =  cList.Select(c=>c.Id).ToArray();
    _appNotifier.ContactTransferred(contactIdList );
