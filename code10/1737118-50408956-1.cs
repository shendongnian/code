    private Activity HandleSystemMessage(Activity message)
    {
        if (message.Type == ActivityTypes.DeleteUserData)
        {
            // Implement user deletion here
            // If we handle user deletion, return a real message
        }
    //......
    //code logic for other messages types
        //......
        else if (message.Type == ActivityTypes.Event && message.Name == "ClientTimezoneOffsetEvent") {
    
            int timezoneOffset = Convert.ToInt32(message.Value);
    
            var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
    
            timezoneOffset = Convert.ToInt32(message.Value);
    
            DateTime newDate = DateTime.UtcNow - new TimeSpan(timezoneOffset / 60, timezoneOffset % 60, 0);
                    
            var greeting = "";
    
            if (newDate.Hour < 12)
            {
                greeting = "Good Morning";
            }
            else if (newDate.Hour > 12 & newDate.Hour <= 17)
            {
                greeting = "Good Afternoon";
            }
            else if (newDate.Hour > 17 & newDate.Hour <= 24)
            {
                greeting = "Good Evening";
            }
    
            var reply = message.CreateReply();
    
            reply.Text = $"{greeting}! UTC time: {DateTime.UtcNow}; Client time: {newDate}";
    
            client.Conversations.ReplyToActivityAsync(reply);
        }
    
        return null;
    }
