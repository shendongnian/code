            try
            {
                //This is declared at the class level and initially set to 0
                //Incrementing with each button click
                clickCount++;
                int defaults = 0;
                defaults |= (int)NotificationDefaults.Sound;
                defaults |= (int)NotificationDefaults.Lights;
                defaults |= (int)NotificationDefaults.Vibrate;
                var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                var chan = new NotificationChannel(CLICKS_CHANNEL, "Button Click", NotificationImportance.Default)
                {
                    LockscreenVisibility = NotificationVisibility.Private
                };
                notificationManager.CreateNotificationChannel(chan);
                var notificationBuilder = new NotificationCompat.Builder(this, CLICKS_CHANNEL)
                    .SetAutoCancel(true)
                    .SetContentText("You've received new messages.")
                    .SetContentTitle("A New Message")
                    .SetNumber(clickCount)
                    //You need to add a icon to your project and get it here
                    .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                    .SetBadgeIconType(NotificationCompat.BadgeIconSmall)
                    .SetDefaults(defaults); //.Build();
                notificationManager.Notify(0, notificationBuilder.Build());
            }
            catch(System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
