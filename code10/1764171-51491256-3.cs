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
    
    else if (message.Type == ActivityTypes.Event && message.Name == "GetUserLocation")
        {
            var userlocation = message.Value;
    
            //your code logic
        }
    
        return null;
    }
