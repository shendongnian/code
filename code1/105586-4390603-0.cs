    NamedPipeServerStream server = new NamedPipeServerStream("Demo");
    server.WaitForConnection();
    MemoryStream stream = new MemoryStream();
    using (BinaryWriter writer = new BinaryWriter(stream))
    {
        writer.Write("print \"hello\"");
        server.Write(stream.ToArray(), 0, stream.ToArray().Length);
    }
    stream.Close();
    server.Disconnect();
    server.Close();
