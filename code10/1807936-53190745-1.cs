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
            }
        }
	}
