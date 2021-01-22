    using System;
    using System.Net.Sockets;
    using System.Net;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication95
    {
        class MySocket : Socket
        {
            readonly string name;
            public string Name
            {
                get { return name; }
            }
    
            public MySocket(string newName, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
                : base(addressFamily, socketType, protocolType)
            {
                name = newName;
            }
    
            protected override void Dispose(bool disposing)
            {
                Console.WriteLine("Socket " + Name + " disposing");
                base.Dispose(disposing);
            }
        }
    
        class Program
        {
            static TcpListener listener;
    
            static void Main(string[] args)
            {
                listener = new TcpListener(IPAddress.Any, 2055);
                listener.Start();
    
                Thread t = new Thread(TcpService);
                t.Start();
    
                Console.WriteLine("TCP server started, listening to port 2055");
    
                SocketTransport tr = new SocketTransport("1", new MySocket("1", AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), new byte[64]);
                tr.Socket.Connect(IPAddress.Loopback, 2055);
                tr.Socket.BeginReceive(tr.Buffer, 0, tr.Buffer.Length, SocketFlags.None, OnReadOne, tr);
                tr = null;
    
                Console.WriteLine("Press enter to trigger GC");
                Console.ReadLine();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
    
            public class SocketTransport : IDisposable
            {
                public Socket Socket;
                public byte[] Buffer;
                public string Name;
                public SocketTransport(string name, Socket socket, byte[] buffer)
                {
                    Name = name;
                    Socket = socket;
                    Buffer = buffer;
                }
    
                public void Dispose()
                {
                    Console.WriteLine("SocketTransport " + Name + " disposing");
                }
    
                ~SocketTransport()
                {
                    Dispose();
                }
            }
    
            public static void OnReadOne(IAsyncResult ar)
            {
                SocketTransport tr = ar.AsyncState as SocketTransport;
                string message = Encoding.ASCII.GetString(tr.Buffer);
                Console.WriteLine("OnReadOne: " + message);
                Socket socket = tr.Socket;
    
                ar = null;
                tr = null;
                // SocketTransport 1 would become eligible for garbage collection here
                // if the caller of OnReadOne didn't hold a reference as a local variable.
                // 
                // As soon as we exit from this method, our caller exits too
                // and the local reference will be no more and SocketTransport 1
                // can be garbage collected. It doesn't matter whether we
                // call EndReceive or not, as illustrated with the triggered GC
                // in OnReadTwo() and the one after pressing enter in Main.
    
                SocketTransport tr2 = new SocketTransport("2", socket, new byte[64]);
                tr2.Socket.BeginReceive(tr2.Buffer, 0, tr2.Buffer.Length, SocketFlags.None, OnReadTwo, tr2);
            }
    
            public static void OnReadTwo(IAsyncResult ar)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
    
                SocketTransport tr = ar.AsyncState as SocketTransport;
                tr.Socket.EndReceive(ar);
                string message = Encoding.ASCII.GetString(tr.Buffer);
                Console.WriteLine("OnReadTwo: " + message);
            }
    
            public static void TcpService()
            {
                using (Socket socket = listener.AcceptSocket())
                {
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);
    
                    Console.WriteLine("Connected: {0}", socket.RemoteEndPoint);
                    try
                    {
                        socket.NoDelay = true;
                        socket.Send(Encoding.ASCII.GetBytes("message 1"));
                        Thread.Sleep(100);
                        socket.Send(Encoding.ASCII.GetBytes("message 2"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
    
                    Console.WriteLine("Disconnecting: {0}", socket.RemoteEndPoint);
                }
            }
        }
    }
