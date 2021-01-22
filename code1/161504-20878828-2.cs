    private void ConnectionCallBack(IAsyncResult iAsyncResult)
    {
    try
    {
    // Get the pipe
    NamedPipeClientStream namedPipeClientStream = (NamedPipeClientStream)iAsyncResult.AsyncState;
    // End the write
    namedPipeClientStream.EndWrite(iAsyncResult);
    namedPipeClientStream.Flush();
    // Get Server Response...
    GetServerResponse(namedPipeClientStream);
    // Flush Data and Close Pipe...
    namedPipeClientStream.Flush();
    namedPipeClientStream.Close();
    namedPipeClientStream.Dispose();
    }
    catch (Exception ex)
    {
    Debug.WriteLine(ex.Message);
    }
    }
