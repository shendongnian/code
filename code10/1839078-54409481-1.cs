    public static void SendSMS(Message message)
    {
    const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    const string authToken = "your_auth_token";
    TwilioClient.Init(accountSid, authToken);
    var message = MessageResource.Create(
        body: message.message_content,
        from: new Twilio.Types.PhoneNumber("+15017122661"), //note: you can let your Twilio Messaging service handle the phone number, I recommend you look into that
        to: new Twilio.Types.PhoneNumber(message.recipient_phone)
        statusCallback: new Uri(TwilioCallBackController.SMSCallBackURL)
    );
    message.twilio_sid = message.Sid;
    db.SaveChanges();
    }
