    class CAA
    {
    
        private Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private IPAddress Target_IP;
        private int Target_Port;
        public static int bPause;
        
        public CAA()
        {
            Target_IP = IPAddress.Parse("x.x.x.x");
            Target_Port = xxx;
    
            try
            {
                IPEndPoint LocalHostIPEnd = new
                IPEndPoint(IPAddress.Any, Target_Port);
                UDPSocket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, 1);
                UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                UDPSocket.Bind(LocalHostIPEnd);
                UDPSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 0);
                UDPSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new
                MulticastOption(Target_IP));
                Console.WriteLine("Starting Recieve");
                Recieve();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e.StackTrace);
            }
        }
    
        private void Recieve()
        {
            try
            {
                IPEndPoint LocalIPEndPoint = new
                IPEndPoint(IPAddress.Any, Target_Port);
                EndPoint LocalEndPoint = (EndPoint)LocalIPEndPoint;
                StateObject state = new StateObject();
                state.workSocket = UDPSocket;
                Console.WriteLine("Begin Recieve");
                UDPSocket.BeginReceiveFrom(state.buffer, 0, state.BufferSize, 0, ref LocalEndPoint, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    
        private void ReceiveCallback(IAsyncResult ar)
        {
            
                IPEndPoint LocalIPEndPoint = new
                IPEndPoint(IPAddress.Any, Target_Port);
                EndPoint LocalEndPoint = (EndPoint)LocalIPEndPoint;
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceiveFrom(ar, ref LocalEndPoint);            
                        
                            
    
                client.BeginReceiveFrom(state.buffer, 0, state.BufferSize, 0, ref LocalEndPoint, new AsyncCallback(ReceiveCallback), state);
        }
    
    
        public static void Main()
        {       
            CAA o = new CAA();        
            Console.ReadLine();
        }
    
        public class StateObject
        {
            public int BufferSize = 512;
            public Socket workSocket;
            public byte[] buffer;
    
            public StateObject()
            {
                buffer = new byte[BufferSize];
            }
        }
    
    }
