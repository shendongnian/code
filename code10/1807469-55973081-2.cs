    [BroadcastReceiver]
        [IntentFilter(new[] { Intent.ActionBootCompleted })]
        public class TestApplicationBroadcastReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                Log.Info("TestApp", "******* Loading Application *******");
    
                try
                {
                    if (intent.Action.Equals(Intent.ActionBootCompleted))
                    {                    
                        Intent service = new Intent(context, typeof(TestService));
                        service.AddFlags(ActivityFlags.NewTask);
                        context.StartService(service);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("TestApp", "******* Error message *******: " + ex.Message);
                }
            }
        }
