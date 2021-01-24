    using (NamedPipeServerStream namedPipeServer = new NamedPipeServerStream("test-pipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte))
    {
        namedPipeServer.WaitForConnection();
        Console.WriteLine("A client has connected!");
        byte[] bytes = Encoding.Default.GetBytes("Hello, it's me!\n");
        namedPipeServer.Write(bytes, 0, bytes.Length);
        namedPipeServer.WaitForPipeDrain();
        var reader = new StreamReader(namedPipeServer);
        var msg = reader.ReadLine();
        Console.WriteLine(msg);
    }
