    Ping myPing = new Ping();
    String host = "google.com";
    byte[] buffer = new byte[32];
    int timeout = 1000;
    PingOptions pingOptions = new PingOptions();
    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
    if (reply.Status == IPStatus.Success) {
      // presumably online
    }
