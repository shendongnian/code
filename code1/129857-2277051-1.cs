    using System.Net;
    using System.Net.Sockets;
    Socket socket =
        new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
    socket.Bind(new IPEndPoint(IPAddress.Parse("X.X.X.X"), 0)); // specify IP address
    socket.ReceiveBufferSize = 2 * 1024 * 1024; // 2 megabytes
    socket.ReceiveTimeout = 500; // half a second
    byte[] incoming = BitConverter.GetBytes(1);
    byte[] outgoing = BitConverter.GetBytes(1);
    socket.IOControl(IOControlCode.ReceiveAll, incoming, outgoing);
