    using System;
    using System.IO;
    using System.Net.Sockets;
    
    namespace ConsoleApp01
    {
        class Program
        {
            public static void Main(string[] args)
            {
                try
                {
                    //TcpClient client = new TcpClient("python.org", 80);
                    TcpClient client = new TcpClient("82.94.164.162", 80);
                    NetworkStream ns = client.GetStream();
                    StreamWriter sw = new StreamWriter(ns);
                    sw.Write("HEAD / HTTP/1.1\r\n"
                           + "User-Agent: Test\r\n"
                           + "Host: www.python.org\r\n"
                           + "Connection: Close\r\n");
                    sw.Flush();
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadKey(true);
            }
        }
    }
