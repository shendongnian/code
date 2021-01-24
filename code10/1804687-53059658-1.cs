        protected override void OnResume()
        {
            base.OnResume();
            var NewSMS = new IntentFilter("android.provider.Telephony.SMS_RECEIVED");
            RegisterReceiver(this.SMSNotificator, NewSMS);
        }
        protected override void OnPause()
        {
            base.OnPause();
            UnregisterReceiver(this.SMSNotificator);
        }
