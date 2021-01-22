    using System.Net;
    using System.Net.Sockets;
    
    public class Test
    {
        public void Send(byte[] rawData, IPEndPoint target)
        {
            // change what you pass to this constructor to your needs
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IPv4);
    
            try
            {
                s.Connect(target);
                s.Send(rawData);
            }
            catch(Exception ex)
            {
                // handle this exception
            }
        }
    }
