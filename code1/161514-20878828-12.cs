    private void ClientRequestHandler(string clientRequest)
    {
    try
    {
    if (this.InvokeRequired)
    {
    this.Invoke(new InvokedDelegate(ClientRequestHandler), clientRequest);
    }
    else
    {
    ProcessClientRequest(clientRequest);
    }
    }
    catch (Exception ex)
    {
    Debug.WriteLine(ex.Message);
    }
    }
    private void ProcessClientRequest(string clientRequest)
    {
    // Display the Client Request...
    richTextBox1.Text = clientRequest;
    PipeServer.SendResponse("Server has received Client Request at: " + DateTime.Now);
    }
