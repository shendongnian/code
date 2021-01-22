        static void Main(string[] args)
        {
            Receiver recv = new Receiver();
            recv.Start();            
        }
    }
    public class Receiver
    {
        public void Start()
        {
            Socket gateSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            gateSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8999));
            gateSocket.Listen(12);
            Thread thGateListen = new Thread(new ParameterizedThreadStart(GateListener));
            thGateListen.Start(gateSocket);
        }
        public void GateListener(object obj)
        {
            Socket gateSocket = (Socket)obj;
            for (; ; )
            {
                Socket newRequest = gateSocket.Accept();
                Console.WriteLine("New Connection Request");
                Thread thReadData = new Thread(new ParameterizedThreadStart(ReadFromSocket));
                thReadData.Start(newRequest);
            }
        }
        public void ReadFromSocket(object obj)
        {
            Socket s = (Socket)obj;
            for (; ; )
            {
                if (s.Available > 0)
                {
                    byte[] buffer = new byte[s.Available];
                    s.Receive(buffer);
                    Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                }
            }
        }
    }
