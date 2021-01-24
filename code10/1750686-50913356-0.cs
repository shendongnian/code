    if (IPAddress.TryParse("**IP String**", out var ip))
    {
          using (var pong = new Ping())
          {
             pong.Send(ip);
             //Etc...
          }  
    }
