    static void Main(string[] args)
    {
        Socket one = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket two = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        one.Bind(ep);
        one.Listen(1);
        two.Connect("127.0.0.1", 12345);
        one = one.Accept();
        NetworkStream s = new NetworkStream(two);
        byte[] buffer = new byte[32];
        s.BeginRead(buffer, 0, 32, new AsyncCallback(ReadCallback), s);
        Console.WriteLine("I'm not blocking");
        /* you'd do some other work here */
        Console.WriteLine("Now I want to wait for NetworkStream to read all data");
        //one.Send(new byte[32]); //send bytes to see what happens
       
        waiter.WaitOne(5000); /* wait up to 5 seconds for socket to get how much you told it to read */
        //one.Close(); // close the socket to show what happens
        Console.WriteLine();
        Console.ReadKey();
    }
    static private System.Threading.ManualResetEvent waiter = new System.Threading.ManualResetEvent(false);
    
    static void ReadCallback(IAsyncResult result)
    {
        NetworkStream stream = (NetworkStream)result.AsyncState;
        int read = 0;
        try
        {
            read = stream.EndRead(result);
            Console.WriteLine(String.Format("Read {0} bytes from the stream", read));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Socket was closed, unable to read");
        }
        finally
        {
            waiter.Set();
        }
    }
}
