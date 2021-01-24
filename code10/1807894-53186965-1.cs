        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
             .SetSmallIcon(Resource.Drawable.Icon)
             .SetContentTitle(messageTitle)
             .SetContentText(messageBody)
             .SetSound(Settings.System.DefaultNotificationUri)
             .SetVibrate(new long[] { 1000, 1000 })
             .SetLights(Color.AliceBlue, 3000, 3000)
             .SetAutoCancel(true)
             .SetContentIntent(pendingIntent);
          if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    String channelId = Context.GetString(Resource.String.default_notification_channel_id);
                    NotificationChannel channel = new NotificationChannel(channelId, MessageTitle, NotificationImportance.Default);
                    channel.Description=(MessageBody);
                    builder.SetChannelId(channelId);
                }
