    using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
    {
        pipeClient.Connect();
        
        using (StreamReader sr = new StreamReader(pipeClient))
        {
            string command;
            while ((command = sr.ReadLine()) != null)
            {
                Console.WriteLine("Received command: {0}", command);
            }
        }
    }
