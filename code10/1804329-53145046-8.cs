    public class PlaybackService : Service, TextToSpeech.IOnInitListener, TextToSpeech.IOnUtteranceCompletedListener
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action.Equals(PlaybackConsts.Start))
            {
                var notification =
                    new Notification.Builder(this)
                    .SetContentTitle(Resources.GetString(Resource.String.ApplicationName))
                    .SetContentText("HELLO WORLD")
                    .SetOngoing(true)
                    .Build();
                StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);
            }
            if (intent.Action.Equals(PlaybackConsts.Start))
            {
                var uri = Android.Net.Uri.Parse(intent.GetStringExtra("uri"));
                var content = MiscellaneousHelper.GetTextFromStream(ContentResolver.OpenInputStream(uri));
                Dictionary = DictionaryFactory.Get(content);
                Playing = true;
                Task.Factory.StartNew(async () =>
                {
                    await PlayDictionary();
                });
            }
            if (intent.Action.Equals(PlaybackConsts.PlayPause))
            {
                bool isChecked = intent.GetBooleanExtra("isChecked", false);
                PlayPause(isChecked);
            }
            if (intent.Action.Equals(PlaybackConsts.NextEntry))
            {
                NextEntry();
            }
            if (intent.Action.Equals(PlaybackConsts.PrevEntry))
            {
                PrevEntry();
            }
            if (intent.Action.Equals(PlaybackConsts.Stop))
            {
                Task.Factory.StartNew(async () =>
                {
                    await Stop();
                });
                
                StopForeground(true);
                StopSelf();
            }
            return StartCommandResult.Sticky;
        }
