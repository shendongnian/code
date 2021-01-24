    public class LocalNotification : ILocalNotification
	{
		public void ShowNotification(string title, string message)
		{
			Context act = ((Activity)MainApplication.FormsContext);
			Intent intent = new Intent(act, typeof(MainActivity));
			// Create a PendingIntent; we're only using one PendingIntent (ID = 0):
			const int pendingIntentId = 0;
			PendingIntent pendingIntent =
				PendingIntent.GetActivity(act, pendingIntentId, intent, PendingIntentFlags.OneShot);
			Notification.Builder builder = new Notification.Builder(act)
				.SetContentIntent(pendingIntent)
			.SetContentTitle(title)
			.SetContentText(message)
			.SetSmallIcon(Resource.Drawable.icon);
			Notification notification = builder.Build();
			NotificationManager notificationManager =
				act.GetSystemService(Context.NotificationService) as NotificationManager;
			const int notificationId = 0;
			notificationManager.Notify(notificationId, notification);
		}
	}
