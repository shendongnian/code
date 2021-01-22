    using System.Net;
    using System.Net.Sockets;
    ...
    IPHostEntry myHostEntry = Dns.GetHostByName("myserver");
    IPEndPoint host = new IPEndPoint(myHostEntry.AddressList[0], myPort);
    Socket s = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream, ProtocolType.Tcp);
    s.Connect(host);
