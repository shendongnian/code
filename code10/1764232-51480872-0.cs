    static void Main(string[] args)
    {
        var props = IPGlobalProperties.GetIPGlobalProperties();
        var conns = props.GetActiveTcpConnections();
        foreach (var conn in conns)
        {
            Console.WriteLine((conn.LocalEndPoint.Port));
        }
        Console.ReadKey();
    }
