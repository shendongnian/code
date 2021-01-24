    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class PlaybackBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var activity = MainActivity.GetInstance(); // if you need your activity here, see further code below
            if (intent.Action == "renderEntry")
            {
                string entryHtml = intent.GetStringExtra("html");
                // omitting code to keep example concise
            }
        }
    }
