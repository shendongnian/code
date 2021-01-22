You can count it in your event handlerclass Server()
{
  private AutoResetEvent connectionWaitHandle = new AutoResetEvent(false);
  public void Start()
  {
    TcpListener listener = new TcpListener(IPAddress.Any, 5555);
    listener.Start();
    while(true)
    {
      IAsyncResult result =  tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, tcpListener);
      connectionWaitHandle.WaitOne(); //Wait until a client has begun handling an event
    }
  }
  private void HandleAsyncConnection(IAsyncResult result)
  {
    TcpListener listener = (TcpListener)result.AsyncState;
    TcpClient client = listener.EndAcceptTcpClient(result);
    connectionWaitHandle.Set(); //Inform the main thread this connection is now handled
    //... Use your TcpClient here
    client.Close();
  }
}</pre>
