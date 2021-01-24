        smsBtn.Click += (s, e) =>
        {
            var phone = phoneNum.Text;
            var message = sms.Text;
            var piSent = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_SENT"), 0);
            var piDelivered = PendingIntent.GetBroadcast(this, 0, new Intent("SMS_DELIVERED"), 0);
            if ((int)Build.VERSION.SdkInt < 23)
            {
                _smsManager.SendTextMessage(phone, null, message, piSent, piDelivered);
                return;
            }
            else {
                if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.SendSms) != (int)Permission.Granted)
                {
                    // Permission is not granted. If necessary display rationale & request.
                    RequestSendSMSPermission();
                }
                else
                {
                    // We have permission, go ahead and send SMS.
                    _smsManager.SendTextMessage(phone, null, message, piSent, piDelivered);
                }
            }
        };
