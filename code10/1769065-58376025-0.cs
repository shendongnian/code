        using Android.Telephony;
        public void sendSMS(string to,string msg)
	    { 
            SmsManager.Default.SendTextMessage(to, null, msg, null, null); 
        }
