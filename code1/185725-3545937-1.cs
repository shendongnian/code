    class Program
    {
        static void Main(string[] args)
        {
            Thread writerThread = new Thread(new ThreadStart(WriterThread));
            writerThread.Start();
    
            Thread readerThread = new Thread(new ThreadStart(ReaderThread));
            readerThread.Start();
        }
    
        static void ReaderThread()
        {
            NamedPipeServerStream server = new NamedPipeServerStream("FD1AF2B4-575A-46E0-8DF5-8AB368CF6645");
            server.WaitForConnection();
    
            using (var reader = new BinaryReader(server))
            {
                string arguments = reader.ReadString();
                Console.WriteLine("Received: {0}", arguments);
            }
        }
    
        static void WriterThread()
        {
            NamedPipeClientStream client = new NamedPipeClientStream("FD1AF2B4-575A-46E0-8DF5-8AB368CF6645");
            client.Connect(Timeout.Infinite);
    
            using (var writer = new BinaryWriter(client))
            {
                writer.Write("/foo /bar:33 /baz:quux");
            }
        }
    }
