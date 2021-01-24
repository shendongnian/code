     public class NotificationListnerExtension : INotificationListnerExtension
        {
            private readonly IHubContext<Notification> _notificationHubContext; 
    
            public NotificationListnerExtension(
                IHubContext<Notification> notificationHubContext)
            {
                _notificationHubContext = notificationHubContext;                
            }
    }
