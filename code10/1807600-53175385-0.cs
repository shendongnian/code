    public void ReceiveMessage(object smsMessage)
        {
            if (AutoReply(smsMessage))
            {
                //Send the office closed message
            }
            else
            {
                //Continue as normal
            }
        }
        public bool AutoReply(object smsMessage)
        {
            bool autoReply = true;
            DateTime msgTime = smsMessage.MessageTime; //This is when your message came in - i'm assuming it will be a DateTime
            TimeSpan openTime = new TimeSpan(08, 0, 0); //This is when your office opens - i have put 08:00
            TimeSpan closeTime = new TimeSpan(17, 0, 0); //....and this is when it closes - i have put 17:00
            if (msgTime.TimeOfDay > openTime && msgTime.TimeOfDay < closeTime) autoReply = false; //Set to true if we're between opening hours
            return autoReply;
        }
