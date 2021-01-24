	[BroadcastReceiver]
	public class ServiceBroadcastReceiver : BroadcastReceiver
	{
        Context context;
        public ServiceBroadcastReceiver(Context context)
        {
           this.context = context;
        }
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent.HasExtra("play"))
			{
               // sent a "play" cmd, do something.
               // context is your activity, you can call methods on it
               (context as SomeActivity)?.PlayReceived();
            }
        }
	}
