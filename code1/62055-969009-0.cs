    public void SmsMessageSend()
    {
        SmsMessage smsMessage = new SmsMessage();
        
        //Set the message body and recipient.
        smsMessage.Body = "Would you like to meet for lunch?";
        smsMessage.To.Add(new Recipient("John Doe", "2065550199"));
        smsMessage.RequestDeliveryReport = true;
        
        //Send the SMS message.
        smsMessage.Send();
        
        return;
        }
