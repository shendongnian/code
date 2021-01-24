           MessageBoard SMSReceiver = new MessageBoard();
            var smsFilter = new
            IntentFilter("android.provider.Telephony.SMS_RECEIVED")
            {
                Priority =
            (int)IntentFilterPriority.HighPriority
            };
            RegisterReceiver(SMSReceiver, smsFilter);
