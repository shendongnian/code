    public static string firstmessage = null;
    /// <summary>
    /// POST: api/Messages
    /// Receive a message from a user and reply to it
    /// </summary>
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
            if (firstmessage == null)
            {
                firstmessage = activity.Text?.ToString();
            }
    
            storeuserinput(activity);
    
            await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
    
        }
        else
        {
            HandleSystemMessage(activity);
        }
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
    
    private void storeuserinput(Activity activity)
    {
        var uid = activity.From.Id;
        var uname = activity.From.Name;
    
        if (activity.Text?.ToLower().ToString() == "no")
        {
            var userinput = firstmessage;
        }
    
        //extract other data from "activity" object
    
        //your code logic here
        //store data in your table storage
    
        //Note: specifcial scenario of user send attachment
    }
