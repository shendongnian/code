    // Response Methods...
    public void SendResponse(string ServerResponse)
    {
    try
    {
    // Fill Buffer with Server Response Data...
    byte[] Buffer = Encoding.UTF8.GetBytes(ServerResponse);
    // Begin Async Write to the Pipe...
    namedPipeServerStream.BeginWrite(Buffer, 0, Buffer.Length, SendResponseCallBack, namedPipeServerStream);
    }
    catch (Exception ex)
    {
    Debug.WriteLine(ex.Message);
    }
    }
    private void SendResponseCallBack(IAsyncResult iAsyncResult)
    {
    try
    {
    // Get the Pipe Handle...
    NamedPipeServerStream namedPipeServerStream = (NamedPipeServerStream)iAsyncResult.AsyncState;
    // End the Write and Flush...
    namedPipeServerStream.EndWrite(iAsyncResult);
    namedPipeServerStream.Flush();
    // Close the Connection and Dispose...
    namedPipeServerStream.Close();
    namedPipeServerStream.Dispose();
    }
    catch (Exception ex)
    {
    Debug.WriteLine(ex.Message);
    }
    }
