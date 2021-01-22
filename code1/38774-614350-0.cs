    using System.Net.NetworkInformation;
    var ping = new Ping();
    var reply = ping.Send("google.com", 60 * 1000); // 1 minute time out (in ms)
    // or...
    reply = ping.Send(new IPAddress(new byte[]{127,0,0,1}), 3000);
