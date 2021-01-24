    using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream(".", "test-pipe", PipeDirection.InOut))
    {
        namedPipeClient.Connect();
        var reader = new StreamReader(namedPipeClient);
        var msg = reader.ReadLine();
        Console.WriteLine(msg);
        byte[] writeBytes = Encoding.Default.GetBytes("Hello from client!\n");
        namedPipeClient.Write(writeBytes, 0, writeBytes.Length);
        namedPipeClient.WaitForPipeDrain();
    }
