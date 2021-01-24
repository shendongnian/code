    class MyClient : TcpClient
    {
        public StreamReader Reader { get; }
        public StreamWriter Writer { get; }
        public MyClient(Socket acceptedSocket)
        {
            this.Client.Dispose();
            this.Client = acceptedSocket;
            this.Active = true;
            Reader = new StreamReader(this.GetStream());
            Writer = new StreamWriter(this.GetStream());
        }
    }
