        static void Main(string[] args)
        {
            Sender s = new Sender();
            s.Send("Hello Socket!");
        }
    }
    class Sender
    {
        public void Send(string s)
        {
            Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sendSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8999));
            sendSocket.Send(System.Text.Encoding.ASCII.GetBytes(s));
        }
    }
