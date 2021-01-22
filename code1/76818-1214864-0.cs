    class Program
    {
        static Thread listenThread;
        static void Main(string[] args)
        {
            try
            {
                using (Mutex mutex = new Mutex(true, "my mutex"))
                {
                    listenThread = new Thread(Listen);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                }
            }
            catch (ApplicationException)
            {
                using (Mutex mutex = Mutex.OpenExisting("my mutex"))
                {
                    mutex.WaitOne();
                    try
                    {
                        using (NamedPipeClientStream client = new NamedPipeClientStream("some pipe"))
                        {
                            using (StreamWriter writer = new StreamWriter(client))
                            {
                                writer.WriteLine("SomeMessage");
                            }
                        }
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
        static void Listen()
        {
            using (NamedPipeServerStream server = new NamedPipeServerStream("some pipe"))
            {
                using (StreamReader reader = new StreamReader(server))
                {
                    for (; ; )
                    {
                        server.WaitForConnection();
                        string message = reader.ReadLine();
                        //Dispatch the message, probably onto the thread your form 
                        //  was contructed on with Form.BeginInvoke
                    }
                }
            }
        }
