    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    using System.Linq;
    class Test
    {
        static void Main(string[] args)
        {
            int port = 1000;
            Console.WriteLine(IsFree(port));
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            server.Start();   
            Console.WriteLine(IsFree(port));
            Console.WriteLine(NextFreePort(port));
        }
        
        static bool IsFree(int port)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] listeners = properties.GetActiveTcpListeners();
            int[] openPorts = listeners.Select(item => item.Port).ToArray<int>();
            return openPorts.All(openPort => openPort != port);
        }
        static int NextFreePort(int port = 0) {
            port = (port > 0) ? port : new Random().Next(1, 65535);
            while (!IsFree(port)) {
                port += 1;
            }
            return port;
        }
    }
