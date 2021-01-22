    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    
    namespace Server
    {
        internal class SimpleServer
        {
            private static SimpleServer server;
            private readonly TcpListener socket;
    
            private SimpleServer(int port)
            {
                Console.WriteLine(">> Starting SimpleServer");
                socket = new TcpListener(port);
                socket.Start(); 
            }
    
            private void DoJob()
            {
                try
                {
                    bool done = false;
                    while (!done)
                    {
                        TcpClient client = socket.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        var reader = new StreamReader(stream, Encoding.UTF8);
                        String str = reader.ReadLine();
                        if (str == null)
                        {
                            done = true;
                        }
                        else
                        {
                            printOut(str, stream);
                            if (str.Trim() == "EXIT")
                            {
                                done = true;
                            }
                        }
                        client.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
    
    
            public static void main(String[] args)
            {
                int port = 8080;
    
                try
                {
                    port = Int32.Parse(args[0]);
                }
                catch (Exception e)
                {
                    // Catch exception and keep going. 
                }
    
                server = new SimpleServer(port);
                server.DoJob();
            }
    
            private void printOut(String str, Stream stream)
            {
                byte[] bytes = Encoding.UTF8.GetBytes("Echo: " + str + "\r\n");
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine(str);
            }
        }
    }
