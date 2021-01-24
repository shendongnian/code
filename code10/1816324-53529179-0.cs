    [BroadcastReceiver(Enabled = true, Exported = true, DirectBootAware = true)]
    [IntentFilter(new string[] {
        Intent.ActionBootCompleted, Intent.ActionLockedBootCompleted, "android.intent.action.QUICKBOOT_POWERON"
    })]
    public class BootReceiver: BroadcastReceiver {
        public override void OnReceive(Context context, Intent intent) {
            //Do something
        }
    }
