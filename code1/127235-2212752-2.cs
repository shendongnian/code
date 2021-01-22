    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Loopback, 8181);
            listener.Start();
            using (var client = listener.AcceptTcpClient())
            using (var stream = client.GetStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
                writer.WriteLine("Upgrade: WebSocket");
                writer.WriteLine("Connection: Upgrade");
                writer.WriteLine("WebSocket-Origin: http://localhost:8080");
                writer.WriteLine("WebSocket-Location: ws://localhost:8181/websession");
                writer.WriteLine("");
            }
            listener.Stop();
        }
    }
