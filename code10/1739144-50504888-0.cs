    [Service]
        public class BackgroundService : Service
        {
    
            static readonly string TAG = "X:" + typeof(Activity_MainMenu).Name;
    
            static readonly int DELAY_BETWEEN_LOG_MESSAGES = 5000;
            static readonly int NOTIFICATION_ID = 10000;
    
            UtcTimestamper timestamper;
            Handler handler;
            Action runnable;
    
            public override void OnCreate()
            {
                base.OnCreate();
    
    
                timestamper = new UtcTimestamper();
                handler = new Handler();
    
                runnable = new Action(() =>
                {
                    if (timestamper != null)
                    {
                        handler.PostDelayed(runnable, DELAY_BETWEEN_LOG_MESSAGES);
                    }
                });
            }
    
            public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId) // HIER DRIN MUSS GECALLED WERDEN!
            {
                DispatchNotificationThatServiceIsRunning();
                return StartCommandResult.Sticky;
            }
    
            public override IBinder OnBind(Intent intent)
            {
                return null;
            }
    
            public override void OnDestroy()
            {
                base.OnDestroy();
                OnCreate();
            }
    
    
            void DispatchNotificationThatServiceIsRunning()
            {
                Notification.Builder notificationBuilder = new Notification.Builder(this)
                    .SetSmallIcon(Resource.Drawable.btn_bookoflifeMainMenu)
                    .SetContentTitle(Resources.GetString(Resource.String.app_name))
                    .SetContentText("TESTING");
    
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.Notify(NOTIFICATION_ID, notificationBuilder.Build());
            }
    
    
        }
