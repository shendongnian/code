    public static bool IsOnline() {
        var pinger = new Ping();
        try {
            return pinger.Send("oursite.com").Status == IPStatus.Success;
        } catch(SocketException) { return false; } catch(PingException) { return false; }
    }
