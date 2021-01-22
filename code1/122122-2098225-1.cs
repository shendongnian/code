    public bool IsServiceRunning(string serviceName)
    {
        string[] services =  client.AllServices();
        foreach( string service in services )
        {
            if( service.Equals( serviceName, StringComparison.OrdinalIgnoreCase ) )
            {
                return true;
            }
        }
        return false;
    }
