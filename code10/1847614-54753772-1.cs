    // Use this for Server Methods
    public static void GetStatus(string message)
        {
            hubContext.Clients.All.acknowledgeMessage($"GetStatus: {message}");
        }
