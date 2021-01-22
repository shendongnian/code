    public static void ValidConnection(ServiceConnection connection, IScope scope)
    {
      scope.Validate(connection.Username, "UserName", StringIs.Limited(6, 256), StringIs.ValidEmail);
      scope.Validate(connection.Password, "Password", StringIs.Limited(1, 256));
      scope.Validate(connection.Endpoint, "Endpoint", Endpoint);
    }
    
    static void Endpoint(Uri obj, IScope scope)
    {
      var local = obj.LocalPath.ToLowerInvariant();
      if (local == "/timeseries.asmx")
      {
        scope.Error("Please, use TimeSeries2.asmx");
      }
      else if (local != "/timeseries2.asmx")
      {
        scope.Error("Unsupported local address '{0}'", local);
      }
    
      if (!obj.IsLoopback)
      {
        var host = obj.Host.ToLowerInvariant();
        if ((host != "ws.lokad.com") && (host != "sandbox-ws.lokad.com"))
          scope.Error("Unknown host '{0}'", host);
      }
 
