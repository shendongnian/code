     namespace MAMN.Droid.Native
    {
    [BroadcastReceiver]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = 
    Int32.MaxValue)]
    public class MessageBoard : BroadcastReceiver
    {
        SmsMessage[] messages;
        public static readonly string INTENT_ACTION = "android.provider.Telephony.SMS_RECEIVED";
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (intent.Action != INTENT_ACTION) return;
                messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);          
                ManageSMS();
            }
            catch (Exception) { }
        }
        public void ManageSMS()
        {
            var dd = messages[0].DisplayMessageBody.ToString();
           string msg = new String(dd.Where(Char.IsDigit).ToArray());
            //this is the message center i have subscribe to get the message text in my pc
            MessagingCenter.Send<object, string>(this, "OTP", msg);
        }
       }
     }
