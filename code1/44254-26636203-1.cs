    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace UdpReciever
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Receiver");
                // This constructor arbitrarily assigns the local port number.
                UdpClient udpClient = new UdpClient();
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));
                try
                {
                    //IPEndPoint object will allow us to read datagrams sent from any source.
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
    
                    string message = String.Empty;
                    do
                    {
    
                        // Blocks until a message returns on this socket from a remote host.
                        Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                        message = Encoding.ASCII.GetString(receiveBytes);
    
                        // Uses the IPEndPoint object to determine which of these two hosts responded.
                        Console.WriteLine("This is the message you received: " +
                                                     message);
                        //Console.WriteLine("This message was sent from " +
                        //                            RemoteIpEndPoint.Address.ToString() +
                        //                            " on their port number " +
                        //                            RemoteIpEndPoint.Port.ToString());
                    }
                    while (message != "exit");
                    udpClient.Close();
                    //udpClientB.Close();
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
    
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
            }
        }
    }
