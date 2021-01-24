    public class Server
    {
        private readonly UdpClient _listener;
        public Server(int port)
        {
            _listener = new UdpClient(port);
        }
        public void Run()
        {
            try
            {
                _listener.BeginReceive(new AsyncCallback(ProcessResult), null);
                Console.WriteLine("[SERVER]: Started");
            }
            catch (Exception e)
            {
                Console.WriteLine("[SERVER][ERR]: {0}", e);
                Console.WriteLine("[SERVER][ERR]: Stopping...");
            }
        }
        private void ProcessResult(IAsyncResult result)
        {
            var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            var received = _listener.EndReceive(result, ref remoteIpEndPoint);
            try
            {
                ProcessReceived(received, remoteIpEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine("[SERVER][ERR]: Error on processing: {0}", e);
            }
            _listener.BeginReceive(new AsyncCallback(ProcessResult), null);
        }
        private void ProcessReceived(byte[] received, IPEndPoint sender)
        {
            Console.WriteLine("[SERVER]: Receieved '{0}'. Sending 'Thank you' to {1}", Encoding.ASCII.GetString(received), sender);
            var reply = Encoding.ASCII.GetBytes("Thank you");
            _listener.SendAsync(reply, reply.Length, sender);
        }
    }
