    public bool IsServiceRunning(string serviceName)
    {
        string[] services =  client.AllServices();
        return services.Any(s => 
            s.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
    }
