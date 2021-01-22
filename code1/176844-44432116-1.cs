    private const string PipeName = "471450d6-70db-49dc-94af-09d3f3eba529"; // same as parent
    public static void Main(string[] args)
    {
        Console.WriteLine("Child process running");
        using (NamedPipeClientStream pipe = new NamedPipeClientStream(".", PipeName, PipeDirection.In))
        {
            pipe.Connect();
            pipe.BeginRead(new byte[1], 0, 1, PipeBrokenCallback, pipe);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    private static void PipeBrokenCallback(IAsyncResult ar)
    {
        // the pipe was closed (parent process died), so exit the child process too
        try
        {
            NamedPipeClientStream pipe = (NamedPipeClientStream)ar.AsyncState;
            pipe.EndRead(ar);
        }
        catch (IOException) { }
        Environment.Exit(1);
    }
