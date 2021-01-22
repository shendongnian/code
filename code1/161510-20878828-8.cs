    try
    {
    namedPipeServerStream = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
    // Wait for a connection here...
    namedPipeServerStream.BeginWaitForConnection(new AsyncCallback(ConnectionCallBack), namedPipeServerStream);
    }
    catch (Exception ex)
    {
    Debug.WriteLine(ex.Message);
    }
