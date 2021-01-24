    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Sockets;
    using System.Net;
    
    namespace server_test
    {
        class program
        {
            static void Main(string[] args)
            {
    
                IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
                TcpListener server = new TcpListener(ip, 8080);
                TcpClient client = default(TcpClient);
    
                try
                {
                    server.Start();
                    Console.WriteLine("server started...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                }
    
            }
        }
    }
