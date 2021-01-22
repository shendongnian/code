    try
    {
    namedPipeClientStream = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
    // Connect with timeout...
    namedPipeClientStream.Connect(TimeOut);
    byte[] buffer = Encoding.UTF8.GetBytes(DataToSend);
    namedPipeClientStream.BeginWrite(buffer, 0, buffer.Length, ConnectionCallBack, namedPipeClientStream);
    }
    catch (TimeoutException ex)
    {
    Debug.WriteLine(ex.Message);
    }
