    public bool IsServiceRunning(string serviceName)
    {
        string[] services =  client.AllServices();
        return Array.Exists(services,
            s => s.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
    }
