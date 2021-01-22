    using System;
    using System.Net;
    using System.Net.Sockets;
    
    namespace icmp_capture
    {
        class Program
        {
            static void Main(string[] args)
            {            
                IPEndPoint ipMyEndPoint = new IPEndPoint(IPAddress.Any, 0);
                EndPoint myEndPoint = (ipMyEndPoint);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);            
                socket.Bind(myEndPoint);
                while (true)
                {
                    Byte[] ReceiveBuffer = new Byte[256];
                    var nBytes = socket.ReceiveFrom(ReceiveBuffer, 256, 0, ref myEndPoint);
                    if (ReceiveBuffer[20] == 3)// ICMP type = Delivery failed
                    {
                        Console.WriteLine("Delivery failed");
                        Console.WriteLine("Returned by: " + myEndPoint.ToString());
                        Console.WriteLine("Destination: " + ReceiveBuffer[44] + "." + ReceiveBuffer[45] + "." + ReceiveBuffer[46] + "." + ReceiveBuffer[47]);
                        Console.WriteLine("---------------");
                    }
                    else {
                        Console.WriteLine("Some (not delivery failed) ICMP packet ignored");
                    }
                }
    
            }
        }
    }
