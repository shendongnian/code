    public string GetClientIP()
    {
        // Get the client IP from the call context.
        object data = CallContext.GetData("ClientIP");
        // If the data is null or not a string, then return an empty string.
        if (data == null || !(data is IPAddress))
            return string.Empty;
        // Return the data as a string.
        return ((IPAddress)data).ToString();
    }
