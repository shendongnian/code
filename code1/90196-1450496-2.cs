    using(TcpClient tcpClient = new TcpClient()) {
        try {
           tcpClient.Connect("localhost", serverPort);
           StreamWriter writer = new StreamWriter(tcpClient.GetStream(), Encoding.UTF8);
           writer.AutoFlush = true;
           writer.WriteLine("login>user,pass");
           writer.WriteLine("print>param1,param2,param3");
        } catch (Exception ex) {
            Console.Error.WriteLine(ex.ToString());
        }
    }
