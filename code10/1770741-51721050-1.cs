    private static readonly string Endpoint = @"Your End Point";
    private static readonly string HubName = @"You Hub Name";
    private static NotificationHubClient Hub { get { return NotificationHubClient.CreateClientFromConnectionString(Endpoint, HubName); } }
    
    public static async Task Send(string[] tags, object data)
    {
        try
       {
    
            string payload = string.Empty;
            string json_gcm = string.Empty;
    
            if (data.GetType() != typeof(string))
            {
                //If your notification data is of type
                payload = JsonConvert.SerializeObject(data);
                json_gcm = "{ \"data\" : " + payload + "}";
            }
            else
            {
                //If your notification data is simply is in string
                payload = Convert.ToString(data);
                json_gcm = "{ \"data\" : {\"message\":\"" + payload + "\"}}";
            }
    
    
            // Android
            NotificationOutcome gcmOutcome = null;
            gcmOutcome = await Hub.SendGcmNativeNotificationAsync(json_gcm, tags);
    
            if (gcmOutcome != null)
            {
                if (!((gcmOutcome.State == NotificationOutcomeState.Abandoned) || (gcmOutcome.State == NotificationOutcomeState.Unknown)))
                {
                    //Do code when notification successfully send to Android
                 }
            }
        }
        catch (Exception ex)
        {
            //Do code when any exception occurred while sending notification  
    
        } 
    }
