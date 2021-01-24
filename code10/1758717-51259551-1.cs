    [Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
    public class GcmNotificationService : GcmListenerService
    {
        //More information on how to set different things from notification can be found here
        //https://docs.microsoft.com/sv-se/xamarin/android/app-fundamentals/notifications/local-notifications
        public override void OnMessageReceived(string from, Bundle data)
        {
            var message = data.GetString("message");
            if (!string.IsNullOrEmpty(message))
            {
                if (!NotificationContextHelper.Handle(message))
                    SendNotification(message);
            }
        }
        private void SendNotification(string message)
        {
            var builder = new Notification.Builder(this)
                    .SetContentTitle("Title")
                    .SetContentText(message)
                    .SetSmallIcon(Resource.Drawable.notification_test)
                    .SetVisibility(NotificationVisibility.Public);
            var notification = builder.Build();
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager.Notify(0, notification);
        }
    }
