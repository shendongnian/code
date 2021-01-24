	[BroadcastReceiver]
	public class ServiceBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent.HasExtra("play"))
			{
               // sent a "play" cmd, do something.
            }
        }
	}
