    public void Run()
    {
        bool WhileOn = true;
        NetworkStream stream;
        string inputLine;
        StreamReader reader;
        try
        {
            using(TcpClient irc = new TcpClient(SERVER, PORT))
            {
            ...
            }
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            Thread.Sleep(5000);
        }
    }
