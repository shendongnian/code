    static void Main()
    {
        ThreadPool.QueueUserWorkItem(w => {
            var asyncserver = new TcpServer();
            asyncserver.Run("192.168.0.7", 5055); // or whatever your local IP Address is
        });
        Console.WriteLine("Press [Enter] to quit");
        Console.ReadLine();
    }
