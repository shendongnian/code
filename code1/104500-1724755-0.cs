    public void Start()
    {
        this.listener.Start();
        Console.WriteLine("Server running...");
        while (true)
        {
            Socket s = this.listener.AcceptSocket();
            ThreadPool.QueueUserWorkItem(this.WorkMethod, s);
        }
    }
    private void WorkMethod(object state)
    {
        using (Socket s = (Socket)state)
        {
            byte[] buffer = new byte[100];
            int count = s.Receive(buffer);
            string message = "Hello from the server";
            byte[] response = Encoding.ASCII.GetBytes(message);
            s.Send(response);
        }
    }
