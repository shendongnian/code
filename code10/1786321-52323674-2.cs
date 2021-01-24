    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    using System.Net;
    
    namespace console
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPAddress address;
                IPAddress.TryParse("192.168.14.173", out address);
                IPEndPoint recPoint = new IPEndPoint(address, 13154);
                IPEndPoint recAnyPoint = new IPEndPoint(IPAddress.Any, 13154);
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("192.168.14.174"), 13154);
    
                // IPEndPoint sendPoint = new IPEndPoint(address, 9999);
                UdpClient send = new UdpClient();
                send.ExclusiveAddressUse = false;
                // no need to use the low level socketoption 
                // send.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                send.Client.Bind(recAnyPoint);
                send.Connect(ipPoint);
                UdpClient receive = new UdpClient();
                
                receive.ExclusiveAddressUse = false;
                // receive.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                receive.Client.Bind(recPoint);
                receive.Connect(ipPoint);
                Byte[] response = null;
                Byte[] command = System.Text.Encoding.Default.GetBytes("NO one");
                try
                {
                    send.Send(command, command.Length);
                    response = receive.Receive(ref ipPoint);
                    Console.WriteLine(System.Text.Encoding.Default.GetString(response));
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
