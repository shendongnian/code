    static void Connect()
    {
        var tcpClient = new MyClient(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:61234/MyService/IAllOfMyOps"));
        Console.WriteLine(tcpClient.OpA());
        Console.WriteLine(tcpClient.OpB());
        tcpClient.Close();
        var namedPipeClient = new MyClient(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/MyService/ILimitedAvailabilityOp"));
        Console.WriteLine(namedPipeClient.OpB());
        Console.WriteLine(namedPipeClient.OpA()); // this would fail
        namedPipeClient.Close();
    }
