    using System.Net;
    using System.Net.Sockets;
    
    [STAThread]
    static void Main(string[] args)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork,
        SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(new IPEndPoint(IPAddress.Any, 8002));
        socket.Connect(new IPEndPoint(IPAddress.Broadcast, 8001));
        socket.Send(System.Text.ASCIIEncoding.ASCII.GetBytes("hello"));
    
        int availableBytes = socket.Available;
        if (availableBytes > 0)
        {
            byte[] buffer = new byte[availableBytes];
            socket.Receive(buffer, 0, availableBytes, SocketFlags.None);
            // buffer has the information on how to connect to the server
        }
    }
